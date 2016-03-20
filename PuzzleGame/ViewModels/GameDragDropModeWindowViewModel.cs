using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
