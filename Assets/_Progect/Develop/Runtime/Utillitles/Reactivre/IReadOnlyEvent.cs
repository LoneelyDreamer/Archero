using System;

namespace Assets._Progect.Develop.Runtime.Utillitles.Reactivre
{
    public interface IReadOnlyEvent
    {
        IDisposable Subscribe(Action action);
    }

      public interface IReadOnlyEvent<T>
    {
        IDisposable Subscribe(Action<T> action);
    }


}
