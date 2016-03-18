using PuzzleGame.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleGame;

namespace PuzzleGame.Models
{
    class Methods
    {
        public IField LoadSave(Game savedGame)
        {
            List<byte[]> LoadedImagePieces = new List<byte[]>();
            DataBase db = new DataBase();
            Dictionary<string, MemoryStream> LoadedImageDic = db.LoadPuzzle(savedGame.ImageID, savedGame.Difficulty);
            
            var parts = savedGame.PartsLocation.Split();
            List<int> LoadedState = new List<int>();

            for (int i = 1; i <= LoadedState.Count; i++ )
            {
                LoadedImagePieces.Add(LoadedImageDic[i.ToString()].GetBuffer());
            }

            foreach (string st in parts)
            {
                LoadedState.Add(int.Parse(st));
            }

            if (savedGame.Type == 1)
            {
                return new Field1(LoadedState, LoadedImagePieces);
            }
            else if (savedGame.Type == 2)
                {
                    return new Field2(LoadedState, LoadedImagePieces);
                }
            else
                throw new ArgumentException();

        }

        //public IField CreateNewGame()

    }
}
