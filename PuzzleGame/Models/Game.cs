using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    public class Game
    {
        public string ImagName { get; set; }
        public int Difficulty { get; set; }
        public int Type { get; set; }
        public string PartsLocation { get; set; }

        public Game(string Name, int dif, int type, string location)
        {
            ImagName = Name;
            Difficulty = dif;
            Type = type;
            PartsLocation = location;
        }
    }
}
