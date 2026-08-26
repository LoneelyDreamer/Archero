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

        private bool _isRunning;
        public void Initialze(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
        }

        public void Run()
        {
            _entity = _entitiesFactory.CreateHero(Vector3.zero);
            _entity.AddCurrentTarget();
            _brainsFactory.CreateMainHeroBrain(_entity, new NearestDamageableTargetSelector(_entity));

            _ghost = _entitiesFactory.CreateGhost(Vector3.zero + Vector3.forward * 5);
            _entitiesFactory.CreateGhost(Vector3.zero + Vector3.forward * 3);
            _entityTeleportedGost = _entitiesFactory.CreateTeleportGhost(Vector3.zero + Vector3.forward * 5);

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if(Input.GetKeyDown(KeyCode.Space))           
                _entity.TakeDamegeRequest.Invoke(50);

            if(Input.GetKeyDown(KeyCode.R))           
                _entity.StartAttackRequest.Invoke();

            if (Input.GetKeyDown(KeyCode.I))
                _brainsFactory.CreateGostBrain(_ghost);

            

            //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            //_entity.MoveDirection.Value = input;
            //_entity.RotationDirection.Value = input;
            if (Input.GetKeyDown(KeyCode.I))
                _entityTeleportedGost.StartTeleportRequest.Invoke();



            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _entity.MoveDirection.Value = input;
            _entity.RotationDirection.Value = input;
        }
    }
}
