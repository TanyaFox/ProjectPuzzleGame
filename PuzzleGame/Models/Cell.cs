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
        public int Count { get; set; }

        public Cell(int current, int count)
        {
            if (current == count)
                IsCorrect = true;
            else
                IsCorrect = false;
            this.Count = count;
            this.CurrentElement = current;
        }
        public Cell(int count)
        {
            IsCorrect = false;
            this.Count = count;
            this.CurrentElement = 1;
        }
    }
}
