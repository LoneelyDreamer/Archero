using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;   
        private BrainsFactory _brainsFactory;
        
        private Entity _entity;
        private Entity _ghost;
        private Entity _entityTeleportedGost;
        private Entity _entityTeleportedGost2;

        [SerializeField] private HeroConfig _heroConfig;
        [SerializeField] private GostConfig _gostConfig;

        private bool _isRunning;
        public void Initialze(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
        }

        public void Run()
        {
            _entity = _entitiesFactory.CreateHero(Vector3.zero, _heroConfig);
            _entity.AddCurrentTarget();
            _brainsFactory.CreateMainHeroBrain(_entity, new NearestDamageableTargetSelector(_entity));

            _ghost = _entitiesFactory.CreateGhost(Vector3.zero + Vector3.forward * 2, _gostConfig);
            _brainsFactory.CreateGhostBrain(_ghost);

            _entityTeleportedGost = _entitiesFactory.CreateTeleportGhost(Vector3.zero + Vector3.forward * 8);
            _entityTeleportedGost.AddCurrentTarget();
            _brainsFactory.CreateSmartTeleportGhostBrain(_entityTeleportedGost, new NearestMinHpInTeleportRadiusTargetSelector(_entityTeleportedGost));

            //_entityTeleportedGost2 = _entitiesFactory.CreateTeleportGhost(Vector3.zero + Vector3.forward * 8);
            //_brainsFactory.CreateRandomTeleportGhostBrain(_entityTeleportedGost2);

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
        }
    }
}
