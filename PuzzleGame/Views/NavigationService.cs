using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using PuzzleGame.Interface;
using PuzzleGame.ViewModels;

namespace PuzzleGame.Views
{
    class NavigationService : INavigationService
    {
        Dictionary<string, Window> _windows = new Dictionary<string, Window>();

        public NavigationService(INavigationService nav)
        {
            _windows["Tag1"] = new GameWindowView();
            _windows["Tag2"] = new GameMiddleWindowView();
            _windows["Tag3"] = new GameHardWindowView();
            _windows["Drag&Drop1"] = new GameDragDropModeWindowView();
            _windows["Drag&Drop2"] = new GameDragDropModeMiddleWindowView();
            _windows["Drag&Drop3"] = new GameDragDropModeHardWindowView();
            _windows["AboutWindow"] = new AboutAuthorsWindowView();
            _windows["NewGame"] = new NewGameWindowView();
            _windows["BeforeNewGame"] = new BeforeNewGameWindowView(nav);
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
