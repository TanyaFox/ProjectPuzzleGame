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
    /// Логика взаимодействия для GameDragDropModeWindowView.xaml
    /// </summary>
    public partial class GameDragDropModeWindowView : Window
    {
        public GameDragDropModeWindowView(int id, int level)
        {
            InitializeComponent();
            GameDragDropModeWindowViewModel vm = new GameDragDropModeWindowViewModel(id, level);
            this.DataContext = vm;
        }

        public GameDragDropModeWindowView(int id, int level, IField field)
        {
            InitializeComponent();
            GameDragDropModeWindowViewModel vm = new GameDragDropModeWindowViewModel(id, level, field);
            this.DataContext = vm;
        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image im = e.Source as Image;
            DataObject data = new DataObject(typeof(ImageSource), im.Source);
            DragDrop.DoDragDrop(im, data, DragDropEffects.Copy);
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
            ((Image)sender).Source = image;
        }
    }
}
