using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PuzzleGame.Interface;
using PuzzleGame.Models;
using System.Windows;

namespace PuzzleGame.ViewModels
{
    class GameWindowViewModel : INotifyPropertyChanged
    {
        PuzzleMethods pz = new PuzzleMethods();
        DataBase db = new DataBase();
        static object lockobj  = new object();

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
            ButtonSavedGameCommand = new Command(arg => ButtonSavedGameClick());
            CallPopulateMethod(id);      
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
                    List<bool> changedActiveButtons = new List<bool>();
                    List<byte[]> changedPictures = new List<byte[]>();
                    _image[_changingCell] = _field.ListCell[_changingCell].Image;
                    _image[buttonNumber] = _field.ListCell[buttonNumber].Image;
                    _isEnabled[buttonNumber] = _field.ListCell[buttonNumber].IsNotCorrect;
                    _isEnabled[_changingCell] = _field.ListCell[_changingCell].IsNotCorrect;
                    changedActiveButtons = _isEnabled;
                    changedPictures = _image;
                    Image = changedPictures;
                    IsEnabled = changedActiveButtons;
                }
                _changingCell = -1;
            }

        }

        public ICommand ButtonSavedGameCommand { get; set; }

        private void ButtonSavedGameClick()
        {

        }

        private async void CallPopulateMethod(int id)
        {
            bool x = false;
            x = await PopulateProperties(id);
            MessageBox.Show("Поздравляем, вы победили!");

        }

        private async Task<bool> PopulateProperties(int id)
        {
            _image = new List<byte[]>();
            _isEnabled = new List<bool>();

            _field = pz.CreateNewGame(1, 1, db.LoadPuzzle(id, 9));
            if (_field != null)
            {
                for (int i = 0; i < _field.ListCell.Count; i++)
                {
                    _image.Add(_field.ListCell[i].Image);
                    _isEnabled.Add(_field.ListCell[i].IsNotCorrect);
                }
            }

            Task t = new Task(() =>
            {
                bool b = false;
                while (!b)
                {
                    b = true;
                    lock (lockobj)
                        for (int i = 0; i < _isEnabled.Count; i++ )
                        {
                            b = b && !_isEnabled[i];
                        }
                }

            });
            t.Start();
            await t;
            return true;
        }

    }
}
