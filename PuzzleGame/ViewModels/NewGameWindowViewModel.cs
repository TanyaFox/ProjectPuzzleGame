using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;

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

        private INavigationService _navigationService;

        private Dictionary<string,string> _gameMode; //Type should be changed later
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

        private Dictionary<int, string> _levelDifficulty; //Type should be changed later
        public Dictionary<int, string> LevelDifficulty
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

        private bool _listOfPictures; //Type should be changed after Igor will add special class for list of miniatures
        public bool ListOfPictures
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

        public NewGameWindowViewModel()
        {
            _gameMode = new Dictionary<string, string>(); //Maybe, these should be implemented somewhere else, special class?
            GameMode["Tag"] = "Пятнашки";
            GameMode["Drag&Drop"] = "Кусочки";

            _levelDifficulty = new Dictionary<int, string>();
            LevelDifficulty[1] = "Легко";
            LevelDifficulty[2] = "Средне";
            LevelDifficulty[3] = "Сложно";

            ButtonPlayCommand = new Command(arg => ButtonPlayClick());

        }

        public ICommand ButtonPlayCommand { get; set; }

        private void ButtonPlayClick()
        {
            //Here should be logic of forming a string from Mode and Difficulty
            //An example of string, that should be put: "Tag" + "&" + "2"
            _navigationService.NavigateTo(""); //Here should be put the name from user's setting (from form)
        }
    }
}
