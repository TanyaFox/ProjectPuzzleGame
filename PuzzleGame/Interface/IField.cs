using PuzzleGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Interface
{
    interface IField
    {
        List<Cell> ListCell { get; }
        List<byte[]> ImagePieces { get; set; }
        void CellChange(int first, int second);
    }
}
