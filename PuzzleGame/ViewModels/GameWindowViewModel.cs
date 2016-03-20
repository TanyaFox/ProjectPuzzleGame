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

        private Field1 _field;

        public Field1 Field
        {
            get { return _field; }
            set { _field = value; }
        }
        

        private INavigationService _navigationService;

        private List<bool> _clickCheckList;
        public List<bool> ClickCheckList
        {
            get { return _clickCheckList; }
            set
            {
                _clickCheckList = value;
                OnPropertyChanged("ClickCheckList");
            }
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

        private bool _isEnabled;
        public bool IsEnabled
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

        private List<string> _buttonNumber;
        public List<string> ButtonNumber
        {
            get
            {
                return _buttonNumber;
            }
            set
            {
                _buttonNumber = value;
                OnPropertyChanged("ButtonNumber");
            }
        }

        public GameWindowViewModel()
        {

            ButtonPressedCommand = new Command(arg => ButtonPressedClick());
            //_field = pz.CreateNewGame(1, 1, db.LoadPuzzle());
            Task t = new Task(() =>
            {
                while (_clickCheckList.Count > 0)
                {
                    foreach (bool a in _clickCheckList)
                        foreach(bool b in ClickCheckList)
                        {
                            if (a & b)
                            { }
                        }
                }
            });
      
        }

        public ICommand ButtonPressedCommand { get; set; }

        private void ButtonPressedClick()
        {

        }
    }
}
