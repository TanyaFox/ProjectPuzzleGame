using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PuzzleGame.Views;
using PuzzleGame.ViewModels;

namespace PuzzleGame
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new MainWindowView()
            {
                DataContext = new MainWindowViewModel()
            };

            mw.Show();
        }
    }
}
