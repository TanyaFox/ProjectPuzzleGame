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

        private bool _gameMode; //Type should be changed later
        public bool GameMode
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

        private bool _listOfPictures; //Type should be changed later
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

        public NewGameWindowViewModel()
        {
            ButtonPlayCommand = new Command(arg => ButtonPlayClick());
        }

        public ICommand ButtonPlayCommand { get; set; }

        private void ButtonPlayClick()
        {
            _navigationService.NavigateTo(""); //Here should be put the name from user's setting (from form)
        }
    }
}
