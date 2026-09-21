using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Utillitles.Reactivre
{
    public class ReactiveEvent<T> : IReadOnlyEvent<T>
    {
        private readonly List<Subscriber<T>> _subsribers = new();
        private readonly List<Subscriber<T>> _toAdd = new();
        private readonly List<Subscriber<T>> _toRemove = new();
        
        public IDisposable Subscribe(Action<T> action)
        {
            Subscriber<T> subscriber = new Subscriber<T>(action, Remove);
            _toAdd.Add(subscriber);
            return subscriber;
        }

        public void Remove(Subscriber<T> subscriber) => _toRemove.Add(subscriber);

        public void Invoke(T arg)
        {
            if (_toAdd.Count > 0)
            {
                _subsribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subscriber<T> subcriber in _toRemove)
                    _subsribers.Remove(subcriber);

                _toRemove.Clear();
            }

            foreach (Subscriber<T> subcriber in _subsribers)
                subcriber.Invoke(arg);
        }
    }

    public class ReactiveEvent : IReadOnlyEvent
    {
        private readonly List<Subscriber> _subsribers = new();
        private readonly List<Subscriber> _toAdd = new();
        private readonly List<Subscriber> _toRemove = new();

        public IDisposable Subscribe(Action action)
        {
            Subscriber subscriber = new Subscriber(action, Remove);
            _toAdd.Add(subscriber);
            return subscriber;
        }

        public void Remove(Subscriber subscriber) => _toRemove.Add(subscriber);

        public void Invoke()
        {
            if (_toAdd.Count > 0)
            {
                _subsribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subscriber subcriber in _toRemove)
                    _subsribers.Remove(subcriber);

                _toRemove.Clear();
            }

            foreach (Subscriber subcriber in _subsribers)
                subcriber.Invoke();
        }

    }
}
