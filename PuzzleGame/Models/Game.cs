using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    public class Game
    {
        public int ImageID { get; set; }
        public int Difficulty { get; set; }
        public int Type { get; set; }
        public string PartsLocation { get; set; }

        public Game(int ID, int dif, int type, string location)
        {
            ImageID = ID;
            Difficulty = dif;
            Type = type;
            PartsLocation = location;
        }
    }
}
