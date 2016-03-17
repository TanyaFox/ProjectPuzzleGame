using PuzzleGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Field2 : IField //Drag'n'drop
    {
        public List<Cell> ListCell
        { get; set; }

        public Field2(int cells)
        {
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= cells; i++)
            {
                Templist.Add(new Cell());
            }
            this.ListCell = Templist;
        }

        public Field2(List<int> CurrentState)
        {
            List<Cell> Templist = new List<Cell>();
            foreach (int i in CurrentState)
            {
                Templist.Add(new Cell(i));
            }
            this.ListCell = Templist;
        }

        public void CellChange(int first, int second)
        {
            if (first == second)
            {
                ListCell[second].CurrentElement = first;
                ListCell[second].IsCorrect = true;
            }
        }
    }
}
