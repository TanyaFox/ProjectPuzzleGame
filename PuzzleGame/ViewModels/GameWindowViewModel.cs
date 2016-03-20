using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;
using PuzzleGame.Models;

namespace PuzzleGame.ViewModels
{
    class GameWindowViewModel : INotifyPropertyChanged
    {
        PuzzleMethods pz = new PuzzleMethods();
        DataBase db = new DataBase();


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private IField _field;

        public IField Field
        {
            get { return _field; }
            set { _field = value; }
        }

        private int _changingCell;

        public int ChangingCell
        {
            get { return _changingCell; }
            set { _changingCell = value; }
        }
        

        private INavigationService _navigationService;


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

        private List<bool> _isEnabled;
        public List<bool> IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public GameWindowViewModel(int id)
        {
            _changingCell = -1;
            ButtonPressedCommand = new Command(arg => ButtonPressedClick(arg));

            _field = pz.CreateNewGame(1, 1, db.LoadPuzzle(id, 1));
            if (_field != null)
            {
                for (int i = 0; i < _field.ListCell.Count; i++)
                {
                    _image.Add(_field.ListCell[i].Image);
                    _isEnabled.Add(_field.ListCell[i].IsCorrect);
                }
            }
      
        }

        public ICommand ButtonPressedCommand { get; set; }

        private void ButtonPressedClick(object bNumber)
        {
            int buttonNumber = Convert.ToInt32(bNumber);
            if (_changingCell == -1)
            {
                _changingCell = buttonNumber;
            }
            else
            {
                if (_changingCell != buttonNumber)
                {
                    _field.CellChange(_changingCell, buttonNumber);
                    _image[_changingCell] = _field.ListCell[_changingCell].Image;
                    _isEnabled[buttonNumber] = _field.ListCell[buttonNumber].IsCorrect;
                }
                _changingCell = -1;
            }

        }


    }
}
