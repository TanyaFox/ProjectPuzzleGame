using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Field
    {
        public List<Cell> ListCell { get; set; }

        public Field(int cells)
        {
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= cells; i++)
            {
                Templist.Add(new Cell(i));
            }
            this.ListCell = Templist;
        }

        public Field(List<int> rnd)
        {
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= rnd.Count; i++)
            {
                Templist.Add(new Cell(rnd[i], i));
            }
        }
    }
}
