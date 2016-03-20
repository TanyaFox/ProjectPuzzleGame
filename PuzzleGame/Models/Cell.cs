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
            IsCorrect = false;
            CurrentElement = current;
            Image = image;
        }
        public Cell()
        {
            IsCorrect = false;
            CurrentElement = 0;
            Image = null;
        }
    }
}
