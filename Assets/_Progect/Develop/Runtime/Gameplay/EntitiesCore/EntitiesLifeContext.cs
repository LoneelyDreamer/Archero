using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesLifeContext : IDisposable
    {
        public event Action<EntityLifeContext> Added;
        public event Action<EntityLifeContext> Released;

        private readonly List<EntityLifeContext> _entities = new();
        private readonly List<EntityLifeContext> _releaseRequest = new();

        public IReadOnlyList<EntityLifeContext> Entities => _entities;

        public void Add(EntityLifeContext entity)
        {
            _entities.Add(entity);

            entity.Initialize();

            Added?.Invoke(entity);
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                _entities[i].OnUpdate(deltaTime);
            }

            foreach (EntityLifeContext entity in _releaseRequest)
            {
                _entities.Remove(entity);
                entity.Dispose();
                Released?.Invoke(entity);
            }

            _releaseRequest.Clear();
        }

        public void Relese(EntityLifeContext entity)
        {
            _releaseRequest.Add(entity);
        }

        public void Dispose()
        {
            foreach (EntityLifeContext entity in _entities)
                entity.Dispose();

            _entities.Clear();      
            _releaseRequest.Clear();
        }
    }
}
