using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;    

        private bool _isRunning;
        public void Initialze(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
        }

        public void Run()
        {
            Entity entity = _entitiesFactory.CreateTestEntity();

            Debug.Log("Направление движения: " +  entity.GetComponent<MoveDirection>().Value.Value.ToString());
            Debug.Log("Скорость движения: " +  entity.GetComponent<MoveSpeed>().Value.Value.ToString());

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
        }
    }
}
