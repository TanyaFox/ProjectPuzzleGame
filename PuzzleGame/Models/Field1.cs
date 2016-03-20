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
        public List<byte[]> ImagePieces { get; set; }

        public Field1(int cells, List<byte[]> imagePieces)
        {
            this.ImagePieces = imagePieces;
            List<int> rndList = new List<int>();
            Random rn = new Random();
            for (int i = 1; i <= cells; i++)
            {
                rndList.Add(i);
            }
            for (int i = 1; i <= rndList.Count; i++)
            {
                int tmp = rndList[0];
                rndList.RemoveAt(0);
                rndList.Insert(rn.Next(rndList.Count), tmp);
            }

            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= rndList.Count; i++)
            {
                Templist.Add(new Cell(rndList[i], ImagePieces[rndList[i]]));
                if (Templist[i].CurrentElement == i)
                    Templist[i].IsCorrect = false;
            }
            this.ListCell = Templist;
        }

        public Field1(List<int> LoadedState, List<byte[]> imagePieces)
        {
            this.ImagePieces = imagePieces;
            List<Cell> Templist = new List<Cell>();
            for (int i = 1; i <= LoadedState.Count; i++)
            {
                Templist.Add(new Cell(LoadedState[i], ImagePieces[LoadedState[i]]));
                if (Templist[i].CurrentElement == i)
                    Templist[i].IsCorrect = false;
            }
        }


        public void CellChange(int first, int second)
        {
            var temp = ListCell[first].CurrentElement;
            ListCell[first].CurrentElement = ListCell[second].CurrentElement;
            ListCell[second].CurrentElement = temp;
            if (ListCell[first].CurrentElement == first)
                ListCell[first].IsCorrect = false;
            if (ListCell[second].CurrentElement == second)
                ListCell[second].IsCorrect = false;
        }
    }
}
