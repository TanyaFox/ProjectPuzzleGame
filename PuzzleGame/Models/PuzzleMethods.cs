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
            
            var parts = savedGame.PartsLocation.Split(',');
            List<int> LoadedState = new List<int>();

            for (int i = 1; i <= LoadedState.Count; i++ )
            {
                LoadedImagePieces.Add(LoadedImageDic[i.ToString()].ToArray());
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

        public IField CreateNewGame(int dif, int type, Dictionary<string, MemoryStream> ImagePieces)
        {
            List<byte[]> LoadedImagePieces = new List<byte[]>();

            for (int i = 1; i <= ImagePieces.Count; i++)
            {
                LoadedImagePieces.Add(ImagePieces[i.ToString()].ToArray());
            }

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
                return new Field1(size, LoadedImagePieces);
            }
            else if (type == 2)
            {
                return new Field2(size, LoadedImagePieces);
            }
            else
                throw new ArgumentException();
        }

        public Dictionary<string, string> DefineGameModes()
        {
            Dictionary<string, string> gameMode = new Dictionary<string, string>();
            gameMode["Пятнашки"] = "Tag";
            gameMode["Кусочки"] = "Drag&Drop";

            return gameMode;
        }

        public Dictionary<string, string> DefineDifficultyLevels()
        {

            Dictionary<string, string> levelDifficulty = new Dictionary<string, string>();
            levelDifficulty["Легко"] = "1";
            levelDifficulty["Средне"] = "2";
            levelDifficulty["Сложно"] = "3";

            return levelDifficulty;
        }

        public string FormMode(string def, string mode)
        {
            return mode + def.ToString();
        }

    }
}
