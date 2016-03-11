﻿using PuzzleGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Field2 : IField
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