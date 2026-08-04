using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntitesFactory : IInitializable, IDisposable
    { 
        private readonly ResourcesAssetsLoader _resources;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly Dictionary<Entity, MonoEntity> _entityToMono = new();

        public MonoEntitesFactory(ResourcesAssetsLoader resources, EntitiesLifeContext entitiesLifeContext)
        {
            _resources = resources;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path)
        {
            MonoEntity prefab = _resources.Load<MonoEntity>(path);

            MonoEntity viewInstance = Object.Instantiate(prefab, position, Quaternion.identity, null);

            viewInstance.Setup(entity);

            _entityToMono.Add(entity, viewInstance);

            return viewInstance;
        }

        public void Initialise()
        {
            _entitiesLifeContext.Released += OnEntityReleased;
        }   

        private void CleanupFor(Entity entity)
        {
            MonoEntity monoEntity = _entityToMono[entity];
            monoEntity.Cleanup(entity);
            Object.Destroy(monoEntity.gameObject);
        }

        private void OnEntityReleased(Entity entity)
        {
            CleanupFor(entity);

            _entityToMono.Remove(entity);
        }

        public void Dispose()
        {
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (Entity entity in _entityToMono.Keys)
                CleanupFor(entity);

            _entityToMono.Clear();
        }
      
    }

}
