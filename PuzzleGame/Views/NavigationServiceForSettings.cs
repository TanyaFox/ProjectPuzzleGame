using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PuzzleGame.Interface;

namespace PuzzleGame.Views
{
    class NavigationServiceForSettings : INavigationService
    {
        Dictionary<string, Window> _windows = new Dictionary<string, Window>();

        public NavigationServiceForSettings()
        {
            _windows["NewGame"] = new NewGameWindowView();
            _windows["CustomNewGame"] = new CustomNewGameWindowView();
        }

        public void NavigateTo(string windowName)
        {
            Window windowObj;
            if (_windows.TryGetValue(windowName, out windowObj))
            {
                windowObj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
