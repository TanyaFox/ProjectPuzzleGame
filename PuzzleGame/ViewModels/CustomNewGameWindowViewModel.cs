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

namespace PuzzleGame.ViewModels
{
    class CustomNewGameWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private INavigationService _navigationService;

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

        private string _flag;
        public string Flag
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
            _gameMode = pz.DefineGameModes();
            _levelDifficulty = pz.DefineDifficultyLevels();

            ButtonPlayCommand = new Command(arg => ButtonPlayClick());
            ButtonUploadPictureCommand = new Command(arg => ButtonUploadPictureClick());

        }

        public ICommand ButtonPlayCommand { get; set; }
        public ICommand ButtonUploadPictureCommand { get; set; }

        private void ButtonPlayClick()
        {
            _navigationService = new NavigationService();

            _navigationService.NavigateTo(pz.FormMode(_gameMode[_mode], _levelDifficulty[_difficulty])); //Here should be put the name from user's setting (from form)
        }

        private void ButtonUploadPictureClick()
        {
            //These all should be in parallel task
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pictures|*.jpeg;*.gif;*.png;*.jpeg";
            dialog.InitialDirectory = Environment.CurrentDirectory;
            Stream st = null;
            if (dialog.ShowDialog() == null)
            {
                try
                {
                    if ((st = dialog.OpenFile()) != null)
                    {
                        using (st)
                        {
                            //int NewPictureId = db.AddPicture(dialog.SafeFileName, dialog.FileName);//Waiting for changes in the AddPicture method.
                            //BitmapFrame bi = BitmapFrame.Create(st);
                            //pz.InitiateFragmentation(NewPictureId, bi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
