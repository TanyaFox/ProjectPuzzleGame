using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    public class Cell
    {
        public bool IsNotCorrect { get; set; }
        public int CurrentElement { get; set; }
        public byte[] Image { get; set; }

        public Cell(int current, byte[] image)
        {
            IsNotCorrect = true;
            CurrentElement = current;
            Image = image;
        }
        public Cell()
        {
            IsNotCorrect = true;
            CurrentElement = 0;
            Image = null;
        }
    }
}
