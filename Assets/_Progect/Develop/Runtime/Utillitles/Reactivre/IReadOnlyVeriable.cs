using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.Reactivre
{
    public interface IReadOnlyVeriable<T>
    {
        IDisposable Subscribe(Action<T, T> action);

        T Value { get; }
    }

}
