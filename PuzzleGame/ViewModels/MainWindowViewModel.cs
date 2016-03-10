using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Views;

namespace PuzzleGame.ViewModels
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ButtonNewGameCommand = new Command(arg => ButtonNewGameClick());
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

        }

        public ICommand ButtonAuthorsCommand { get; set; }

        private void ButtonAuthorsClick()
        {

        }

        public ICommand ButtonExitCommand { get; set; }

        private void ButtonExitClick()
        {

        }
    }
}
