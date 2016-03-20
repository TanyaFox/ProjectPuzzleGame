using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame.Interface
{
    public interface INavigationServiceGames
    {
        void NavigateTo(string windowName, int id, int level, IField field);
    }
}
