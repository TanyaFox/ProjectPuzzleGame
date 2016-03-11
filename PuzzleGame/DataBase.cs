using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace PuzzleGame
{
    class DataBase
    {
        public string conString="";

        public Dictionary<string, string> LoadMiniatures()
        {
            Dictionary<string, string> Miniatures = new Dictionary<string, string>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT p.Name, p.Miniature FROM dbo.Picture as p", connection))//список миниатюр
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i = i + 2)
                            {
                                Miniatures.Add(reader.GetString(i), reader.GetString(i + 1));
                            }
                        }
                    }
                }
                connection.Close();
            }
            return Miniatures;
        }


        public Dictionary<string, MemoryStream> LoadPazzle(string PictureName, int GameLevel)//Метод возвращает словарь типа "картинка-положение картинки"
        {
            Dictionary<string, MemoryStream> PazzleParts = new Dictionary<string, MemoryStream>();
            using (SqlConnection connection = new SqlConnection(conString))
            {

                var cmd = new SqlCommand("ЗагрузкаПазла", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", PictureName);
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
                            PazzleParts.Add(reader.GetString(i + 1), mStream);
                        }

                    }

                }

                connection.Close();
            }
            return PazzleParts;
        }

        public void SafeGame(string ImageName, int Type, int Difficulty)
        { }

    }
}

