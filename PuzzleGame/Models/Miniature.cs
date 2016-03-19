using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Miniature
    {
        public int IdImage { get; set; }
        public string ImageName { get; set; }
        public string Picture { get; set; }

        public Miniature(int id, string name, string pic)
        {
            IdImage = id;
            ImageName = name;
            Picture = pic;
        }
    }
}
