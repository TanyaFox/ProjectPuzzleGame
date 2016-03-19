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
    class BeforeNewGameWindowViewModel
    {
        private INavigationService _navigation;

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
            }
        }

        public Action<bool> CloseAction { get; set; }

        public BeforeNewGameWindowViewModel()
        {
            ButtonFromDBCommand = new Command(arg => ButtonFromDBClick());
            ButtonUploadCommand = new Command(arg => ButtonUploadClick());
        }

        public ICommand ButtonFromDBCommand { get; set; }

        private void ButtonFromDBClick()
        {
            _navigation = new NavigationService();
            _navigation.NavigateTo("NewGame");
            Flag = true;
            CloseAction(Flag);
        }

        public ICommand ButtonUploadCommand { get; set; }

        private void ButtonUploadClick()
        {
            _navigation = new NavigationService();
            _navigation.NavigateTo("CustomNewGame");
            Flag = true;
            CloseAction(Flag);
        }
    }
}
