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

        private readonly CollidersRegestryService _colllidersRegestryService;

        private readonly Dictionary<EntityLifeContext, MonoEntity> _entityToMono = new();

        public MonoEntitesFactory(
            ResourcesAssetsLoader resources, 
            EntitiesLifeContext entitiesLifeContext,
            CollidersRegestryService colllidersRegestryService)
        {
            _resources = resources;
            _entitiesLifeContext = entitiesLifeContext;
            _colllidersRegestryService = colllidersRegestryService;
        }

        public MonoEntity Create(EntityLifeContext entity, Vector3 position, string path)
        {
            MonoEntity prefab = _resources.Load<MonoEntity>(path);

            MonoEntity viewInstance = Object.Instantiate(prefab, position, Quaternion.identity, null);

            viewInstance.Initialize(_colllidersRegestryService);

            viewInstance.Link(entity);

            _entityToMono.Add(entity, viewInstance);

            return viewInstance;
        }

        public void Initialise()
        {
            _entitiesLifeContext.Released += OnEntityReleased;
        }   

        private void CleanupFor(EntityLifeContext entity)
        {
            MonoEntity monoEntity = _entityToMono[entity];
            monoEntity.Cleanup(entity);
            Object.Destroy(monoEntity.gameObject);
        }

        private void OnEntityReleased(EntityLifeContext entity)
        {
            CleanupFor(entity);

            _entityToMono.Remove(entity);
        }

        public void Dispose()
        {
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (EntityLifeContext entity in _entityToMono.Keys)
                CleanupFor(entity);

            _entityToMono.Clear();
        }
      
    }

}
