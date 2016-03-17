using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;
using PuzzleGame.Views;

namespace PuzzleGame.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        public INavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        //private bool _flag;
        //public bool Flag
        //{
        //    get
        //    {
        //        return _flag;
        //    }
        //    set
        //    {
        //        _flag = value;
        //        OnPropertyChanged("Flag");
        //    }
        //}

        public MainWindowViewModel()
        {
            _navigationService = new NavigationService();
            ButtonNewGameCommand = new Command(arg => ButtonNewGameClick());
            ButtonSavedGameCommand = new Command(arg => ButtonSavedGameClick());
            ButtonAuthorsCommand = new Command(arg => ButtonAuthorsClick());
            //ButtonExitCommand = new Command(arg => ButtonExitClick());
        }

        public ICommand ButtonNewGameCommand { get; set; }

        private void ButtonNewGameClick()
        {
            _navigationService.NavigateTo("BeforeNewGame");
        }

        public ICommand ButtonSavedGameCommand { get; set; }

        private void ButtonSavedGameClick()
        {
            //Logic for receiving data about the last saved game from DB

            string keyForWindowCreating = "Tag1"; //Here should be key from DB
            switch (keyForWindowCreating)
            {
                case "Tag1":
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
                case "Tag2":
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
                case "Tag3":
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
                case "Drag&Drop1":
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
                case "Drag&Drop2":
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
                case "Drag&Drop3":
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
                default:
                    _navigationService.NavigateTo(keyForWindowCreating);
                    break;
            }
        }

        public ICommand ButtonAuthorsCommand { get; set; }

        private void ButtonAuthorsClick()
        {
            _navigationService.NavigateTo("AboutWindow");
        }

        //public ICommand ButtonExitCommand { get; set; }

        //private void ButtonExitClick()
        //{
        //    Flag = true;
        //    CloseAction(Flag);
        //}

        //public Action<bool> CloseAction { get; set; }
    }
}
