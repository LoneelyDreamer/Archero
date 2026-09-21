using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.LoadingScreen
{
    public interface ILoadingScreen
    {
        bool IsShown {  get; }
        void Show();
        void Hide();
    }
}
