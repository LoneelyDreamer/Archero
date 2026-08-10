using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class CollidersRegestryService
    {
        private readonly Dictionary<Collider, Entity> _colliderToEntity = new();

        public void Regester(Collider collider, Entity entity)
        {
            _colliderToEntity.Add(collider, entity);
        }

        public void Unregester(Collider collider)
        {
            _colliderToEntity.Remove(collider);
        }

        public Entity GetBy(Collider collider)
        {
            if (_colliderToEntity.TryGetValue(collider, out Entity entity))
                return entity;

            return null;
        }
    }
}
