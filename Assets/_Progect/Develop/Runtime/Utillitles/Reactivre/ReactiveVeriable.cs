using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.Reactivre
{
    public class ReactiveVeriable<T> : IReadOnlyVeriable<T> where T : IEquatable<T>
    {
        private readonly List<Subscriber<T, T>> _subsribers = new();
        private readonly List<Subscriber<T, T>> _toAdd = new();
        private readonly List<Subscriber<T, T>> _toRemove = new();

        public T _value;
        public ReactiveVeriable() => _value = default;
        public ReactiveVeriable(T value) => _value = value;

        public T Value
        { 
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;

                if (_value.Equals(oldValue) == false)
                    Invoke(oldValue, value);
            }
        }

        public IDisposable Subscribe(Action<T, T> action) 
        {
            Subscriber<T, T> subscriber = new Subscriber<T, T>(action, Remove);
            _toAdd.Add(subscriber);
            return subscriber;
        }

        public void Remove(Subscriber<T, T> subscriber) => _toRemove.Add(subscriber);

        private void Invoke(T oldValue, T newValue)
        {
            if (_toAdd.Count > 0)
            {
                _subsribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0) 
            {
                foreach (Subscriber <T,T> subcriber in _toRemove)                
                    _subsribers.Remove(subcriber);
                
                _toRemove.Clear();
            }

            foreach (Subscriber<T, T> subcriber in _subsribers)
                subcriber.Invoke(oldValue, newValue);
        }

    }
}
