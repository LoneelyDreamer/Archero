using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Infrastructure.DI
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Registration> _container = new();

        private readonly List<Type> _requests = new();

        private readonly DIContainer _parant;

        public DIContainer() : this(null)
        {
        }

        public DIContainer(DIContainer parant) => _parant = parant;
        

        public bool IsAlreadyRegister<T>()
        {
            if(_container.ContainsKey(typeof(T)))
                return true;

            if(_parant != null)
                return _parant.IsAlreadyRegister<T>();

            return false;
        }

        public IRegistrationOptions RegisterAsSingle<T>(Func<DIContainer, T> creator)
        {
            if (IsAlreadyRegister<T>())
                throw new InvalidOperationException($"{typeof(T)} already registered");

            Registration registration = new Registration(container => creator.Invoke(container));
            _container.Add(typeof(T), registration);

            return registration;
        }

        public T Resolve<T>()
        {
            if (_requests.Contains(typeof(T)))
                throw new InvalidOperationException($"Cycle resolve for {typeof(T)}");

            _requests.Add(typeof(T));

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))
                    return (T)registration.CreatInstanceFrom(this);

                if(_parant != null)
                    return _parant.Resolve<T>();

            }
            finally
            {
                _requests.Remove(typeof(T));
            }          

            throw new InvalidOperationException($"Registration for {typeof(T)} not exsist");
        }
        public void Initialize()
        {
            foreach (Registration registration in _container.Values)
            {
                if (registration.IsNonLazy)
                    registration.CreatInstanceFrom(this);
            }
        }

    }
}
