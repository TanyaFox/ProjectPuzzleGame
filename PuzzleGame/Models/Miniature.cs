using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Miniature
    {
        public int IdImage { get; set; }
        public string ImageName { get; set; }
        public byte[] Picture { get; set; }

        public Miniature(int id, string name, byte[] pic)
        {
            IdImage = id;
            ImageName = name;
            Picture = pic;
        }
    }
}
