using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
        }

        public Entity CreateTestEntity()
        {
            Entity entity = CreateEmpty();

            entity.AddComponent(new MoveDirection() { Value = new ReactiveVeriable<Vector3>(Vector3.forward)})
                  .AddComponent(new MoveSpeed() { Value = new ReactiveVeriable<float>(10) });

            entity.AddSystem(new MovementSystem());

            return entity;
        }

        public Entity CreateEmpty() => new Entity();

    }
}
