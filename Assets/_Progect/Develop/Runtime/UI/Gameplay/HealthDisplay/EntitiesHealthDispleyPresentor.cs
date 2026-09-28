using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.HealthDisplay
{
    public class EntitiesHealthDispleyPresentor : IPresentor
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly EntitiesHealthDispley _view;

        private readonly GameplayPresentorFactory _gameplayPresentorFactory;
        private readonly ViewsFactory _viewsFactory;

        public EntitiesHealthDispleyPresentor(
            EntitiesLifeContext entitiesLifeContext,
            EntitiesHealthDispley view, 
            GameplayPresentorFactory gameplayPresentorFactory, 
            ViewsFactory viewsFactory)
        {
            _entitiesLifeContext = entitiesLifeContext;
            _view = view;
            _gameplayPresentorFactory = gameplayPresentorFactory;
            _viewsFactory = viewsFactory;
        }

        private Dictionary<Entity, EntityHealthBarInfo> _entityToHealthBarInfo = new();

        public void Initialise()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
            _entitiesLifeContext.Released += OnEntityReleased;

            foreach(Entity entity in _entitiesLifeContext.Entities)
                OnEntityAdded(entity);
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (EntityHealthBarInfo info in _entityToHealthBarInfo.Values)
                DisposeFor(info);

            _entityToHealthBarInfo.Clear();
        }

        private void OnEntityReleased(Entity entity)
        {
            if (_entityToHealthBarInfo.ContainsKey(entity))
                RemoveHelthBarFor(entity);
        }

        private void OnEntityAdded(Entity entity)
        {
            if(entity.TryGetHealthBarPoint(out Transform healthBarPoint))
            {
                BarWithText healthBarView = null;

                if (entity.HasComponent<IsMainHero>())
                    healthBarView = _viewsFactory.Create<BarWithText>(ViewIDs.MainHeroHealthBar);
                else
                    healthBarView = _viewsFactory.Create<BarWithText>(ViewIDs.SimpleHealthBar);

                _view.Add(healthBarView);

                EntityHealthPrethenter entityHealthPrethenter = _gameplayPresentorFactory.CreateEntityHealthPrethenter(entity, healthBarView);
                entityHealthPrethenter.Initialise();

                IDisposable removeReson = entity.IsDead.Subscribe((oldValue, isDead) =>
                {
                    if (isDead)
                        RemoveHelthBarFor(entity);
                   
                });

                _entityToHealthBarInfo.Add(entity, new EntityHealthBarInfo(healthBarPoint ,removeReson, entityHealthPrethenter));
            }
        }

        public void LateUpdate()
        {
            foreach (KeyValuePair<Entity, EntityHealthBarInfo> info in _entityToHealthBarInfo)
                _view.UpdatePositionFor(info.Value.HealthPrethenter.Bar, info.Value.HealthBarPoint.position);
        }

        private void RemoveHelthBarFor(Entity entity)
        {
            EntityHealthBarInfo info = _entityToHealthBarInfo[entity];
            DisposeFor(info);
            _entityToHealthBarInfo.Remove(entity);
        }

        private void DisposeFor(EntityHealthBarInfo info)
        {
            info.RemoveReson.Dispose();

            _view.Remove(info.HealthPrethenter.Bar);
            _viewsFactory.Release(info.HealthPrethenter.Bar);

            info.HealthPrethenter.Dispose();
        }

        private class EntityHealthBarInfo
        {
            public EntityHealthBarInfo(
                Transform healthBarPoint,
                IDisposable removeReson,
                EntityHealthPrethenter healthPrethenter)
            {
                HealthBarPoint = healthBarPoint;
                RemoveReson = removeReson;
                HealthPrethenter = healthPrethenter;
            }

            public Transform HealthBarPoint { get; }
            public IDisposable RemoveReson { get; }
            public EntityHealthPrethenter HealthPrethenter { get; }
        }
    }   

}
