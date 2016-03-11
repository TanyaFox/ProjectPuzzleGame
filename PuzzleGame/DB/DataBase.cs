using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace PuzzleGame.DB
{
    public class DataBase
    {
        public string ConString;

        public Dictionary LoadMiniatures()
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
    }

    public Dictionary LoadPazzle(string PictureName, int GameLevel)//Метод возвращает словарь типа "картинка-положение"
    {
        Dictionary<int, MemoryStream> PazzleParts = new Dictionary<int, MemoryStream>();
        using (SqlConnection connection = new SqlConnection(conString))
        {

            var cmd = new SqlCommand("ЗагрузкаПазла", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", PictureName);
            cmd.Parameters.AddWithValue("@Level", GameLevel);
            connection.Open();
            string name = "";
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
}
