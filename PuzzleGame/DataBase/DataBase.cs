using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using PuzzleGame.Models;

namespace PuzzleGame
{
    class DataBase
    {
        public string conString = "Data Source=localhost;Initial Catalog=Pazzle;Integrated Security=True";

        public List<Miniature> LoadMiniatures()
        {
            List<Miniature> Miniatures = new List<Miniature>();
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
            return Miniatures;
        }


        public Dictionary<string, MemoryStream> LoadPuzzle(int ImageId, int GameLevel)//Метод возвращает словарь типа "картинка-положение картинки"
        {
            Dictionary<string, MemoryStream> PuzzleParts = new Dictionary<string, MemoryStream>();
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
                            PuzzleParts.Add(reader.GetString(i + 1), mStream);
                        }
                    }
                }

                connection.Close();
            }
            return PuzzleParts;
        }

        public void SaveGame(int ImageId, int Type, int Difficulty, string PartLocation)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {

                var cmd = new SqlCommand("СохранениеИгры", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageName", ImageId);
                cmd.Parameters.AddWithValue("@Mode", Type);
                cmd.Parameters.AddWithValue("@Level", Difficulty);
                cmd.Parameters.AddWithValue("@Location", PartLocation);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddPicture(string ImageName, string ImageAdress)
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
                connection.Close();
            }
        }

        public void AddPartsOfPicture(int ImageId, byte[] imageBytes, int Difficulty, int PartLocation)
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

        public Game LoadGame()
        {
            Game LastGame = new Game(1, 0, 0, "");
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
            return LastGame;
        }
    }


}

