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

        public void NavigateTo(string windowName, int id, int level)
        {
            Window windowObj;
            _windows = new Dictionary<string, Window>()
            { 
                {"Tag1", new GameWindowView(id, level)},
                {"Tag2", new GameMiddleWindowView(id, level)},
                {"Tag3", new GameHardWindowView(id, level)},
                {"Drag&Drop1", new GameDragDropModeWindowView(id, level)},
                {"Drag&Drop2", new GameDragDropModeMiddleWindowView(id, level)},
                {"Drag&Drop3", new GameDragDropModeHardWindowView(id, level)}
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

        public void NavigateTo(string windowName, int id, int level, IField field)
        {
            Window windowObj;
            _windows = new Dictionary<string, Window>()
            { 
                {"Tag1", new GameWindowView(id, level, field)},
                {"Tag2", new GameMiddleWindowView(id, level, field)},
                {"Tag3", new GameHardWindowView(id, level, field)},
                {"Drag&Drop1", new GameDragDropModeWindowView(id, level, field)},
                {"Drag&Drop2", new GameDragDropModeMiddleWindowView(id, level, field)},
                {"Drag&Drop3", new GameDragDropModeHardWindowView(id, level, field)}
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
