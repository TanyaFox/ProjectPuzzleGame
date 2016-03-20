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
    /// Логика взаимодействия для GameDragDropModeHardWindowView.xaml
    /// </summary>
    public partial class GameDragDropModeHardWindowView : Window
    {
        public GameDragDropModeHardWindowView(int id, int level)
        {
            InitializeComponent();
            GameDragDropModeWindowViewModel vm = new GameDragDropModeWindowViewModel(id, level);
            this.DataContext = vm;
        }

        public GameDragDropModeHardWindowView(int id, int level, IField field)
        {
            InitializeComponent();
            GameDragDropModeWindowViewModel vm = new GameDragDropModeWindowViewModel(id, level, field);
            this.DataContext = vm;
        }
    }
}
