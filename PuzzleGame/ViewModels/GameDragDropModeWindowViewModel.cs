﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PuzzleGame.Interface;
using PuzzleGame.Models;

namespace PuzzleGame.ViewModels
{
    class GameDragDropModeWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        int Id;
        int Level;
        int cells;

        PuzzleMethods pz = new PuzzleMethods();
        DataBase db = new DataBase();

        private IField _field;

        public IField Field
        {
            get { return _field; }
            set { _field = value; }
        }

        private List<byte[]> _image;
        public List<byte[]> Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        private List<bool> _isAllow;
        public List<bool> IsAllow
        {
            get
            {
                return _isAllow;
            }
            set
            {
                _isAllow = value;
                OnPropertyChanged("IsAllow");
            }
        }

        private List<byte[]> _listOfParts;
        public List<byte[]> ListOfParts
        {
            get
            {
                return _listOfParts;
            }
            set
            {
                _listOfParts = value;
                OnPropertyChanged("ListOfParts");
            }
        }


        public GameDragDropModeWindowViewModel(int id, int level)
        {
            try
            {
                Id = id;
                Level = level;
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }
        }

        public GameDragDropModeWindowViewModel(int id, int level, IField field)
        {
            try
            {
                Id = id;
                Level = level;
                _field = field;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка!" + e.Message);
            }
        }
    }
}
