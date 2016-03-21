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
using System.Windows;

namespace PuzzleGame.ViewModels
{
    class NewGameWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private INavigationServiceGames _navigationServiceGame;

        private Dictionary<string, string> _gameMode;
        public Dictionary<string, string> GameMode
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

        private List<Miniature> _listOfPictures;
        public List<Miniature> ListOfPictures
        {
            get
            {
                return _listOfPictures;
            }
            set
            {
                _listOfPictures = value;
                OnPropertyChanged("ListOfPictures");
            }
        }

        private Miniature _selectedImage;
        public Miniature SelectedImage
        {
            get
            {
                return _selectedImage;
            }
            set
            {
                _selectedImage = value;
                OnPropertyChanged("SelectedImage");
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

        PuzzleMethods pz = new PuzzleMethods();
        DataBase db = new DataBase();

        public NewGameWindowViewModel()
        {
            try
            {
                _gameMode = pz.DefineGameModes();
                _levelDifficulty = pz.DefineDifficultyLevels();
                _listOfPictures = db.LoadMiniatures(); //this should be in parallel task in order to prevent UI from blocking
                ButtonPlayCommand = new Command(arg => ButtonPlayClick());
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }

        }

        public ICommand ButtonPlayCommand { get; set; }

        private void ButtonPlayClick()
        {
                _navigationServiceGame = new NavigationServiceForGames();
                _navigationServiceGame.NavigateTo(pz.FormMode(_gameMode[_mode], _levelDifficulty[_difficulty]), _selectedImage.IdImage, Convert.ToInt32(_levelDifficulty[_difficulty]));
            
        }
    }
}
