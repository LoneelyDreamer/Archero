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
                    foreach (Subscriber<T, T> subscriber in _subsribers)
                        subscriber.Invoke(oldValue, value);
            }
        }

        public IDisposable Subscribe(Action<T, T> action) 
        {
            Subscriber<T, T> subscriber = new Subscriber<T, T>(action, Remove);
            _subsribers.Add(subscriber);
            return subscriber;
        }

        public void Remove(Subscriber<T, T> subscriber) => _subsribers.Remove(subscriber);


    }
}
