using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class Entity
    {
        private readonly Dictionary<Type, IEntityComponent> _componets = new();

        public Entity AddComponent<TComponent>(TComponent component) where TComponent : class, IEntityComponent 
        {
            _componets.Add(typeof(TComponent), component);
            return this;
        }

        public bool HasComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            return _componets.ContainsKey(typeof(TComponent));
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : class, IEntityComponent
        {
            if(_componets.TryGetValue(typeof(TComponent), out IEntityComponent findedObject))
            {
                component = (TComponent)findedObject;
                return true;
            }

            component = null;
            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            if (TryGetComponent(out TComponent component) == false)
                throw new ArgumentException($"Entity no exist {typeof(TComponent)}");

            return component;
        }
    }
}
