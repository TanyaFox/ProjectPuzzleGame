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

        public Cell(int current)
        {
            IsCorrect = false;
            CurrentElement = current;
        }
        public Cell()
        {
            IsCorrect = false;
            CurrentElement = 0;
        }
    }
}
