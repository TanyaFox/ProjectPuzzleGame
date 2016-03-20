using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PuzzleGame.Interface;

namespace PuzzleGame.Views
{
    public class NavigationServiceForGames : INavigationServiceGames
    {
        Dictionary<string, Window> _windows;

        public NavigationServiceForGames()
        {
        }

        public void NavigateTo(string windowName, int id)
        {
            Window windowObj;
            _windows = new Dictionary<string, Window>()
            { 
                {"Tag1", new GameWindowView(id)},
                {"Tag2", new GameMiddleWindowView(id)},
                {"Tag3", new GameHardWindowView(id)},
                {"Drag&Drop1", new GameDragDropModeWindowView()},
                {"Drag&Drop2", new GameDragDropModeMiddleWindowView()},
                {"Drag&Drop3", new GameDragDropModeHardWindowView()}
            };

            if (_windows.TryGetValue(windowName, out windowObj))
            {
                windowObj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка! Возможно, ты не верно выбрал параметры игры.");
            }
        }
    }
}
