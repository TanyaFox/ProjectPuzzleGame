using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Field1
    {
        public List<Cell> ListCell { get; set; }

        public Field1(int cells)
        {
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= cells; i++)
            {
                Templist.Add(new Cell(i));
            }
            this.ListCell = Templist;
        }

        public Field1(List<int> rnd)
        {
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= rnd.Count; i++)
            {
                Templist.Add(new Cell(rnd[i], i));
            }
        }

        public void CellChange(int first, int second)//Для «пятнашек»
        {
            Cell temp = new Cell(second, first);
            ListCell[second] = new Cell(ListCell[first].CurrentElement, second);
            ListCell[first] = temp;
        }
    }
}
