using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using PuzzleGame.Models;
using System.Windows;

namespace PuzzleGame
{
    class DataBase
    {
        public string conString = "Data Source=localhost;Initial Catalog=Pazzle;Integrated Security=True";

        public List<Miniature> LoadMiniatures()
        {
            List<Miniature> Miniatures = new List<Miniature>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT p.Id, p.Name, p.Miniature FROM dbo.Picture as p", connection))//список миниатюр
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i = i + 3)
                                {

                                    int bLength = (int)reader.GetBytes(2, i, null, 0, int.MaxValue);
                                    byte[] bBuffer = new byte[bLength];
                                    reader.GetBytes(2, i, bBuffer, 0, bLength);
                                    MemoryStream mStream = new MemoryStream(bBuffer);
                                    Miniatures.Add(new Miniature(reader.GetInt32(i), reader.GetString(i + 1), mStream.ToArray()));
                                }
                            }
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            { MessageBox.Show("Error: Could not download pictures from database. Original error: " + ex.Message); }

            return Miniatures;
        }


        public Dictionary<string, MemoryStream> LoadPuzzle(int ImageId, int GameLevel)//Метод возвращает словарь типа "картинка-положение картинки"
        {
            Dictionary<string, MemoryStream> PuzzleParts = new Dictionary<string, MemoryStream>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {

                    var cmd = new SqlCommand("ЗагрузкаПазла", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ImageId);
                    cmd.Parameters.AddWithValue("@Level", GameLevel);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i = i + 2)
                            {
                                int bLength = (int)reader.GetBytes(0, i, null, 0, int.MaxValue);
                                byte[] bBuffer = new byte[bLength];
                                reader.GetBytes(0, i, bBuffer, 0, bLength);
                                MemoryStream mStream = new MemoryStream(bBuffer);
                                PuzzleParts.Add(reader.GetString(i + 1).Trim(), mStream);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error: Could not download puzzle from database. Original error: " + ex.Message); }
            return PuzzleParts;
        }

        public void SaveGame(int ImageId, int Type, int Difficulty, string PartLocation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {

                    var cmd = new SqlCommand("СохранениеИгры", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImageId", ImageId);
                    cmd.Parameters.AddWithValue("@Mode", Type);
                    cmd.Parameters.AddWithValue("@Level", Difficulty);
                    cmd.Parameters.AddWithValue("@Location", PartLocation);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error: Could not save current game in database. Original error: " + ex.Message); }
        }

        public int AddPicture(string ImageName, string ImageAdress)
        {
            int id = 0;
            try
            {
                FileStream fStream = new FileStream(ImageAdress, FileMode.Open, FileAccess.Read);
                Byte[] imageBytes = new byte[fStream.Length];
                fStream.Read(imageBytes, 0, imageBytes.Length);

                using (SqlConnection connection = new SqlConnection(conString))
                {

                    var cmd = new SqlCommand("ДобавлениеИзображения", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", ImageName);
                    cmd.Parameters.AddWithValue("@Miniature", imageBytes);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT ('dbo.Picture')", connection))//список миниатюр
                    {

                         id = Convert.ToInt32(cmd1.ExecuteScalar());
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error: Could not add new image into database. Original error: " + ex.Message); }
            return id;
        }



        public void AddPartsOfPicture(int ImageId, byte[] imageBytes, int Difficulty, int PartLocation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    var cmd = new SqlCommand("ДобавлениеЧасти", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImageId", ImageId);
                    cmd.Parameters.AddWithValue("@Part", imageBytes);
                    cmd.Parameters.AddWithValue("@Level", Difficulty);
                    cmd.Parameters.AddWithValue("@Location", PartLocation);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error: Could not add puzzle part into database. Original error: " + ex.Message); }
        }

        public Game LoadGame()
        {
            Game LastGame = new Game(1, 0, 0, "");
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT l.ImageName, l.[Level], l.Mode, l.Location FROM dbo.LastGame as l", connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LastGame = new Game(reader.GetInt32(reader.GetOrdinal("ImageId")), reader.GetInt32(reader.GetOrdinal("Level")), reader.GetInt32(reader.GetOrdinal("Mode")), reader.GetString(reader.GetOrdinal("Location")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error: Could not load a game from database. Original error: " + ex.Message); }

            return LastGame;
        }
    }


}

