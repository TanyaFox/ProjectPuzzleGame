using PuzzleGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Models
{
    class Methods
    {
        public IField LoadSave(Game savedGame)
        {
            var parts = savedGame.PartsLocation.Split();
            List<int> LoadedState = new List<int>();
            foreach (string st in parts)
            {
                LoadedState.Add(int.Parse(st));
            }

            if (savedGame.Type == 1)
            {
                return new Field1(LoadedState);
            }
            else if (savedGame.Type == 2)
            {
                return new Field2(LoadedState);
            }
            else
                throw new ArgumentException();

        }

    }
}
