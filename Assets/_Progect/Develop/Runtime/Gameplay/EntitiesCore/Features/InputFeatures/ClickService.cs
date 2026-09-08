using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Mines;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures
{
    public class ClickService
    {
        private readonly Camera _camera;    
        private readonly MainHeroHolderService _mainHeroHolder;
        private readonly IInputService _inputService;   
        private readonly ConfigsProviderServise _configsProviderServise;
      
        private readonly StageProviderService _stageProviderService;
        private readonly MinesFactory _minesFactory;

        private MineConfig _mineConfig;

        public ClickService(
                CollidersRegestryService collidersRegestry,
                MainHeroHolderService mainHeroHolder,
                IInputService inputService,
                ConfigsProviderServise configsProviderServise,
                StageProviderService stageProviderService,
                MinesFactory minesFactory)
        {
            _camera = Camera.main;        
            _mainHeroHolder = mainHeroHolder;
            _inputService = inputService;         
            _configsProviderServise = configsProviderServise;
            _mineConfig = _configsProviderServise.GetConfig<MineConfig>();
        
            _stageProviderService = stageProviderService;
            _minesFactory = minesFactory;
        }

        private readonly float _minSpawnDistance = 1f;  // Минимальное расстояние от героя
        private readonly float _maxSpawnDistance = 20f; // Максимальное расстояние для спавна

        public void Update()
        {
            if (_inputService.IsEnabled == false)
                return;

            if (_inputService.IsAttackPressed == false)
                return;

            Entity hero = _mainHeroHolder.MainHero;
            if (hero == null || hero.IsDead.Value)
                return;

            // Получаем мировые координаты на полу
            if (TryGetWorldPositionOnGround(_inputService.TouchPosition, out Vector3 worldPosition) == false)
                return;

            // Ограничиваем расстояние от героя
            Vector3 spawnPosition = ClampDistanceFromHero(worldPosition, hero.Transform.position);

            _minesFactory.Create(spawnPosition, _mineConfig);
        }

        public void SetRightConfig(MineConfig mineConfig)
        {
            _mineConfig = mineConfig;
        }

        private bool TryGetWorldPositionOnGround(Vector3 screenPosition, out Vector3 worldPosition)
        {
            worldPosition = Vector3.zero;

            if (_camera == null)
            {
                Debug.LogError("Camera is null in ClickService");
                return false;
            }

            Ray ray = _camera.ScreenPointToRay(screenPosition);

            // Создаём плоскость на уровне Y=0 (для top-down игры)
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float enter))
            {
                worldPosition = ray.GetPoint(enter);
                return true;
            }

            return false;
        }

        private Vector3 ClampDistanceFromHero(Vector3 targetPosition, Vector3 heroPosition)
        {
            Vector3 directionToTarget = targetPosition - heroPosition;
            float distance = directionToTarget.magnitude;

            // Если клик слишком близко к герою - спавним на минимальном расстоянии
            if (distance < _minSpawnDistance)
            {
                return heroPosition + directionToTarget.normalized * _minSpawnDistance;
            }

            // Если клик слишком далеко - спавним на максимальном расстоянии
            if (distance > _maxSpawnDistance)
            {
                return heroPosition + directionToTarget.normalized * _maxSpawnDistance;
            }

            // Иначе спавним точно по клику
            return targetPosition;
        }
    }
}
