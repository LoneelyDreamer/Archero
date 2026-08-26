using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Utillitles.Reactivre
{
    public class ReactiveVeriable<T> : IReadOnlyVeriable<T>
    {
        private readonly List<Subscriber<T, T>> _subsribers = new();
        private readonly List<Subscriber<T, T>> _toAdd = new();
        private readonly List<Subscriber<T, T>> _toRemove = new();

        private T _value;
        private IEqualityComparer<T> _comparer;
        public ReactiveVeriable() : this(default)
        {
        }
        public ReactiveVeriable(T value) : this(value, EqualityComparer<T>.Default)
        {
        }

        public ReactiveVeriable(T value, IEqualityComparer<T> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public T Value
        { 
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;

                if (_comparer.Equals(oldValue, value) == false)
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
