using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.DB
{
    public class DataBase
    {
        public string ConString;

        public void LoadMiniatures()
        {
            Dictionary<string, string> Miniatures = new Dictionary<string, string>;
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
}
