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
using System.Windows;

namespace PuzzleGame.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private INavigationServiceGames _navigationServiceForGames;

        private INavigationService _navigationService;
        public INavigationService NavigationService { get; set; }

        PuzzleMethods pz = new PuzzleMethods();
        DataBase db = new DataBase();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public MainWindowViewModel()
        {
            try
            {
                ButtonNewGameCommand = new Command(arg => ButtonNewGameClick());
                ButtonSavedGameCommand = new Command(arg => ButtonSavedGameClick());
                ButtonAuthorsCommand = new Command(arg => ButtonAuthorsClick());
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }
        }

        public ICommand ButtonNewGameCommand { get; set; }

        private void ButtonNewGameClick()
        {
            try
            {
                _navigationService = new NavigationService();
                _navigationService.NavigateTo("BeforeNewGame");
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }
        }

        public ICommand ButtonSavedGameCommand { get; set; }

        private void ButtonSavedGameClick()
        {
            try
            {
                _navigationServiceForGames = new NavigationServiceForGames();
                Game g = db.LoadGame();
                int Id = g.ImageID;
                int level;
                string dif;
                string mode;
                switch (g.Difficulty)
                {
                    case 9:
                        {
                            level = 1;
                            dif = "1";
                            break;
                        }
                    case 20:
                        {
                            level = 2;
                            dif = "2";
                            break;
                        }
                    case 36:
                        {
                            level = 3;
                            dif = "3";
                            break;
                        }
                    default:
                        throw new ArgumentException();
                }
                switch (g.Type)
                {
                    case 1:
                        {
                            mode = "Tag";
                            break;
                        }
                    case 2:
                        {
                            mode = "Drag&Drop";
                            break;
                        }
                    default:
                        throw new ArgumentException();
                }
                IField LoadedField = pz.LoadSave(g);
                _navigationServiceForGames.NavigateTo(pz.FormMode(mode, dif), Id, level, LoadedField);
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }
            
        }

        public ICommand ButtonAuthorsCommand { get; set; }

        private void ButtonAuthorsClick()
        {
            try
            {
                _navigationService = new NavigationService();
                _navigationService.NavigateTo("AboutWindow");
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }
        }
    }
}
