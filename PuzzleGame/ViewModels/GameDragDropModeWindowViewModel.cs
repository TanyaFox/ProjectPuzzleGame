using System;
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

        private List<byte[]> _selectedPart;
        public List<byte[]> SelectedPart
        {
            get
            {
                return _selectedPart;
            }
            set
            {
                _selectedPart = value;
                OnPropertyChanged("SelectedPart");
            }
        }


        public GameDragDropModeWindowViewModel(int id, int level)
        {
            try
            {
                
                Id = id;
                Level = level;
                switch (Level)
                {
                    case 1:
                        {
                            cells = 9;
                            break;
                        }
                    case 2:
                        {
                            cells = 20;
                            break;
                        }
                    case 3:
                        {
                            cells = 36;
                            break;
                        }
                    default:
                        throw new ArgumentException();
                }
                _field = pz.CreateNewGame(Level, 2, db.LoadPuzzle(Id, cells));
                if (_field != null)
                {
                    for (int i = 0; i < _field.ListCell.Count; i++)
                    {
                        _image.Add(_field.ListCell[i].Image);
                        _isAllow.Add(_field.ListCell[i].IsNotCorrect);
                    }
                }
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
