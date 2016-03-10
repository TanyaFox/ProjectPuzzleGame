using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Views;

namespace PuzzleGame.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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

        public MainWindowViewModel()
        {
            ButtonNewGameCommand = new Command(arg => ButtonNewGameClick());
            ButtonSavedGameCommand = new Command(arg => ButtonSavedGameClick());
            ButtonAuthorsCommand = new Command(arg => ButtonAuthorsClick());
            //ButtonExitCommand = new Command(arg => ButtonExitClick());
        }

        public ICommand ButtonNewGameCommand { get; set; }

        private void ButtonNewGameClick()
        {
            var newGameWindow = new NewGameWindowView();
            newGameWindow.ShowDialog();
        }

        public ICommand ButtonSavedGameCommand { get; set; }

        private void ButtonSavedGameClick()
        {
            //Logic for receiving data about the last saved game from DB

            string keyForWindowCreating = "Tag1"; //Here should be key from DB
            switch (keyForWindowCreating)
            {
                case "Tag1":
                    var gameWindow = new GameWindowView();
                    gameWindow.ShowDialog();
                    break;
                case "Tag2":
                    var gameMiddleWindow = new GameMiddleWindowView();
                    gameMiddleWindow.ShowDialog();
                    break;
                case "Tag3":
                    var gameHardWindow = new GameHardWindowView();
                    gameHardWindow.ShowDialog();
                    break;
                case "Drag&Drop1":
                    var gameDragDropWindow = new GameDragDropModeWindowView();
                    gameDragDropWindow.ShowDialog();
                    break;
                case "Drag&Drop2":
                    var gameDragDropMiddleWindow = new GameDragDropModeMiddleWindowView();
                    gameDragDropMiddleWindow.ShowDialog();
                    break;
                case "Drag&Drop3":
                    var gameDragDropHardWindow = new GameDragDropModeHardWindowView();
                    gameDragDropHardWindow.ShowDialog();
                    break;
                default:
                    // Message about error should be there
                    break;
            }
        }

        public ICommand ButtonAuthorsCommand { get; set; }

        private void ButtonAuthorsClick()
        {
            var aboutWindow = new AboutAuthorsWindowView();
            aboutWindow.ShowDialog();
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
