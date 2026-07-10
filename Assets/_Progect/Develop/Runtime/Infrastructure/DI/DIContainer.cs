using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Infrastructure.DI
{
    public class DIContainer
    {
        private readonly Dictionary<Type, Registration> _container = new();
    }

    public class Registration
    {
        private Func<DIContainer, object> _creator;
        private object _cashedInstance;

        public Registration(Func<DIContainer, object> creator) => _creator = creator;
       
        public object CreatObjectFrom(DIContainer container)
        {
            if(_cashedInstance != null)
            {
                return _cashedInstance;
            }

            if (_creator == null)
                throw new InvalidOperationException("Not has instance or creator");

            _cashedInstance = _creator.Invoke(container);

            return _cashedInstance;
        }
    }

}
