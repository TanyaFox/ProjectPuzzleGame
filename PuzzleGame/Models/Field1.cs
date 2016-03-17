using PuzzleGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Field1 : IField//Пятнашки
    {
        public List<Cell> ListCell { get; set; }

        public Field1(List<int> rnd)
        {
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= rnd.Count; i++)
            {
                Templist.Add(new Cell(rnd[i]));
                if (Templist[i].CurrentElement == i)
                    Templist[i].IsCorrect = true;
            }
            this.ListCell = Templist;
        }

        public void CellChange(int first, int second)
        {
            var temp = ListCell[first].CurrentElement;
            ListCell[first].CurrentElement = ListCell[second].CurrentElement;
            ListCell[second].CurrentElement = temp;
            if (ListCell[first].CurrentElement == first)
                ListCell[first].IsCorrect = true;
            if (ListCell[second].CurrentElement == second)
                ListCell[second].IsCorrect = true;
        }
    }
}
