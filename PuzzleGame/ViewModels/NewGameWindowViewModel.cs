﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;
using PuzzleGame.Views;
using PuzzleGame.Models;

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

        private bool _selectedImage; //Type should be changed after Igor will add special class for list of miniatures
        public bool SelectedImage
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

        public NewGameWindowViewModel()
        {
            //_navigationService = new NavigationService();
            _gameMode = pz.DefineGameModes();
            _levelDifficulty = pz.DefineDifficultyLevels();
            ButtonPlayCommand = new Command(arg => ButtonPlayClick());
      
        }

        public ICommand ButtonPlayCommand { get; set; }

        private void ButtonPlayClick()
        {
            _navigationService = new NavigationService();
            _navigationService.NavigateTo(pz.FormMode(_gameMode[_mode], _levelDifficulty[_difficulty]));  //Here should be put the name from user's setting (from form)
        }
    }
}
