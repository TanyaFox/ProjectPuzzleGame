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

        public NavigationService()
        {
            _windows["Drag&Drop1"] = new GameDragDropModeWindowView();
            _windows["Drag&Drop2"] = new GameDragDropModeMiddleWindowView();
            _windows["Drag&Drop3"] = new GameDragDropModeHardWindowView();
            _windows["AboutWindow"] = new AboutAuthorsWindowView();
            _windows["BeforeNewGame"] = new BeforeNewGameWindowView();
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
