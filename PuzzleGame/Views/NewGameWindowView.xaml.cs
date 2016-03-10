﻿using System;
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
using PuzzleGame.ViewModels;

namespace PuzzleGame.Views
{
    /// <summary>
    /// Логика взаимодействия для NewGameWindowView.xaml
    /// </summary>
    public partial class NewGameWindowView : Window
    {
        public NewGameWindowView()
        {
            InitializeComponent();

            NewGameWindowViewModel vm = new NewGameWindowViewModel();
            this.DataContext = vm;
        }
    }
}
