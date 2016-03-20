using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Cell
    {
        public bool IsCorrect { get; set; }
        public int CurrentElement { get; set; }
        public byte[] Image { get; set; }

        public Cell(int current, byte[] image)
        {
            IsCorrect = true;
            CurrentElement = current;
            Image = image;
        }
        public Cell()
        {
            IsCorrect = true;
            CurrentElement = 0;
            Image = null;
        }
    }
}
