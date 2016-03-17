using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;
using PuzzleGame.Views;

namespace PuzzleGame.ViewModels
{
    class BeforeNewGameWindowViewModel
    {
        private INavigationService _navigation;

        public BeforeNewGameWindowViewModel(INavigationService nav)
        {
            _navigation = nav;
            ButtonFromDBCommand = new Command(arg => ButtonFromDBClick());
            ButtonUploadCommand = new Command(arg => ButtonUploadClick());
        }

        public ICommand ButtonFromDBCommand { get; set; }

        private void ButtonFromDBClick()
        {
            _navigation.NavigateTo("NewGame");
        }

        public ICommand ButtonUploadCommand { get; set; }

        private void ButtonUploadClick()
        {

        }
    }
}
