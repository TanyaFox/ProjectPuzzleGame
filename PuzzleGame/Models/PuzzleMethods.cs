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
    class PuzzleMethods
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

        public IField CreateNewGame(int dif, int type, List<byte[]> imagePieces)
        {
            int size;
            switch (dif)
            {
                case 1:
                    size = 9;
                    break;
                case 2:
                    size = 20;
                    break;
                case 3:
                    size = 36;
                    break;
                default:
                    throw new ArgumentException();
            }

            if (type == 1)
            {
                return new Field1(size, imagePieces);
            }
            else if (type == 2)
            {
                return new Field2(size, imagePieces);
            }
            else
                throw new ArgumentException();
        }

        public Dictionary<string, string> DefineGameModes()
        {
            Dictionary<string, string> gameMode = new Dictionary<string, string>();
            gameMode["Tag"] = "Пятнашки";
            gameMode["Drag&Drop"] = "Кусочки";

            return gameMode;
        }

        public Dictionary<int, string> DefineDifficultyLevels()
        {

            Dictionary<int, string> levelDifficulty = new Dictionary<int, string>();
            levelDifficulty[1] = "Легко";
            levelDifficulty[2] = "Средне";
            levelDifficulty[3] = "Сложно";

            return levelDifficulty;
        }

        public string FormMode(int def, string mode)
        {
            return mode + def.ToString();
        }

    }
}
