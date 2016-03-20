using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;
using PuzzleGame.Views;
using PuzzleGame.Models;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace PuzzleGame.ViewModels
{
    class CustomNewGameWindowViewModel : INotifyPropertyChanged
    {
        int Id;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private INavigationServiceGames _navigationServiceForGames;

        private Dictionary<string,string> _gameMode;
        public Dictionary<string,string> GameMode
        {
            get
            {
                return _gameMode;
            }
            set
            {
                _gameMode = value;
                OnPropertyChanged("GameMode");
            }
        }

        private Dictionary<string, string> _levelDifficulty;
        public Dictionary<string, string> LevelDifficulty
        {
            get
            {
                return _levelDifficulty;
            }
            set
            {
                _levelDifficulty = value;
                OnPropertyChanged("LevelDifficulty");
            }
        }

        private string _mode;
        public string Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
                OnPropertyChanged("Mode");
            }
        }

        private string _difficulty;
        public string Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

        private bool _flag;
        public bool Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
                OnPropertyChanged("Flag");
            }
        }

        private string _progressLabel;
        public string ProgressLabel
        {
            get
            {
                return _progressLabel;
            }
            set
            {
                _progressLabel = value;
                OnPropertyChanged("ProgressLabel");
            }
        }

        PuzzleMethods pz = new PuzzleMethods();
        DataBase db = new DataBase();

        public CustomNewGameWindowViewModel()
        {
            try
            {
                _gameMode = pz.DefineGameModes();
                _levelDifficulty = pz.DefineDifficultyLevels();

                ButtonPlayCommand = new Command(arg => ButtonPlayClick());
                ButtonUploadPictureCommand = new Command(arg => ButtonUploadPictureClick());
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка" + e.Message);
            }

        }

        public ICommand ButtonPlayCommand { get; set; }
        public ICommand ButtonUploadPictureCommand { get; set; }

        private void ButtonPlayClick()
        {
            try
            {
                _navigationServiceForGames = new NavigationServiceForGames();
                _navigationServiceForGames.NavigateTo(pz.FormMode(_gameMode[_mode], _levelDifficulty[_difficulty]), Id, Convert.ToInt32(_levelDifficulty[_difficulty]));
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка" + e.Message);
            }
        }

        private void ButtonUploadPictureClick()
        {
            Flag = true;
            ProgressLabel = "Загружаем картинку..";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pictures|*.jpg;*.jpeg";
            dialog.InitialDirectory = Environment.CurrentDirectory;
            if (dialog.ShowDialog() != null)
            {
                try
                {

                    int NewPictureId = db.AddPicture(dialog.SafeFileName, dialog.FileName);
                    Bitmap bm = (Bitmap)Image.FromFile(dialog.FileName);
                    BitmapImage bi = pz.BitmapToImageSource(bm);
                    Id = NewPictureId;
                    pz.InitiateFragmentation(NewPictureId, bi);
                    Flag = false; //here should be Flag = wait метод от 5 строк выше
            ProgressLabel = "Готово!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            
        }

    }
}
