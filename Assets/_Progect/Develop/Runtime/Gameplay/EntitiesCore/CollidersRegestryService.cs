using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class CollidersRegestryService
    {
        private readonly Dictionary<Collider, EntityLifeContext> _colliderToEntity = new();

        public void Regester(Collider collider, EntityLifeContext entity)
        {
            _colliderToEntity.Add(collider, entity);
        }

        public void Unregester(Collider collider)
        {
            _colliderToEntity.Remove(collider);
        }

        public EntityLifeContext GetBy(Collider collider)
        {
            if (_colliderToEntity.TryGetValue(collider, out EntityLifeContext entity))
                return entity;

            return null;
        }
    }
}
