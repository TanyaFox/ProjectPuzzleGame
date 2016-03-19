using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PuzzleGame.Models
{
    class Miniature
    {
        public int IdImage { get; set; }
        public string ImageName { get; set; }
        public BitmapImage Picture { get; set; }

        public Miniature(int id, string name, byte[] pic)
        {
            IdImage = id;
            ImageName = name;
            using (var ms = new System.IO.MemoryStream(pic))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                Picture = image;
            }
            
        }
    }
}
