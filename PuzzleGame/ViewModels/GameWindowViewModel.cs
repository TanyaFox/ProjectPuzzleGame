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
        //CustomNewGameWindowViewModel cng = new CustomNewGameWindowViewModel();
        //NewGameWindowViewModel ng = new NewGameWindowViewModel();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private Field1 _field;

        public Field1 Field
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

        public GameWindowViewModel()
        {
            _changingCell = -1;
            ButtonPressedCommand = new Command(arg => ButtonPressedClick(arg));
            //if (ng != null)
            //    ng.ImageSelected += a => pz.GetNewGamePicture(a);
            //else
            //    cng.ImageSelected += a => pz.GetNewGamePicture(a);
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

        private void ButtonPressedClick(object buttonNumber)
        {
            if (_changingCell == -1)
            {
                _changingCell = (int)buttonNumber;
            }
            else
            {
                if (_changingCell != (int)buttonNumber)
                {
                    _field.CellChange(_changingCell, (int)buttonNumber);
                    _image[_changingCell] = _field.ListCell[_changingCell].Image;
                    _isEnabled[(int)buttonNumber] = _field.ListCell[(int)buttonNumber].IsCorrect;
                }
                _changingCell = -1;
            }

        }


    }
}
