using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Part
    {
        private byte[] _piece;

        public byte[] Piece
        {
            get { return _piece; }
            set { _piece = value; }
        }

        private int _trueNumber;

        public int TrueNumber
        {
            get { return _trueNumber; }
            set { _trueNumber = value; }
        }

        public Part()
        {

        }
        
        
    }
}
