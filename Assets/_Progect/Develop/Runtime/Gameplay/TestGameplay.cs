using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Enemies;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;   
        private BrainsFactory _brainsFactory;
        
        private EntityLifeContext _entity;
        private EntityLifeContext _ghost;

        [SerializeField] private HeroConfig _heroConfig;
        [SerializeField] private GostConfig _gostConfig;

        private MainHeroFactory _mainHeroFactory;
        private EnemiesFactory _enemiesFactory;

        private bool _isRunning;
        public void Initialze(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();

            _mainHeroFactory = _container.Resolve<MainHeroFactory>();
            _enemiesFactory = _container.Resolve<EnemiesFactory>();
        }

        public void Run()
        {
            _entity = _mainHeroFactory.Create(Vector3.zero);

            _ghost = _enemiesFactory.Create(Vector3.zero + Vector3.forward * 5, _gostConfig);

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
        }
    }
}
