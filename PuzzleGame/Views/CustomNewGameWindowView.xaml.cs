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
    /// Логика взаимодействия для CustomNewGameWindowView.xaml
    /// </summary>
    public partial class CustomNewGameWindowView : Window
    {
        public CustomNewGameWindowView()
        {
            InitializeComponent();

            CustomNewGameWindowViewModel vm = new CustomNewGameWindowViewModel();
            this.DataContext = vm;
        }
    }
}
