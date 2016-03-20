using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PuzzleGame.Interface;
using PuzzleGame.ViewModels;

namespace PuzzleGame.Views
{
    /// <summary>
    /// Логика взаимодействия для GameMiddleWindowView.xaml
    /// </summary>
    public partial class GameMiddleWindowView : Window
    {
        public GameMiddleWindowView(int id, int level)
        {
            InitializeComponent();
            GameWindowViewModel vm = new GameWindowViewModel(id, level);
            this.DataContext = vm;
        }

        public GameMiddleWindowView(int id, int level, IField field)
        {
            InitializeComponent();
            GameWindowViewModel vm = new GameWindowViewModel(id, level, field);
            this.DataContext = vm;
        }
    }
}
