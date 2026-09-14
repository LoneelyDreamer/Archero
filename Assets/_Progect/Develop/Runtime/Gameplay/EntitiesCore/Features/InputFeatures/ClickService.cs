using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Mines;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures
{
    public enum ClickMode
    {
        None,
        InstallMines,   // клик = поставить мину (Const), списание золота
        Explode         // клик = взрыв в точке (Instant), урон по площади
    }


    public class ClickService
    {
        private readonly Camera _camera;    
        private readonly MainHeroHolderService _mainHeroHolder;
        private readonly IInputService _inputService;   
        private readonly MinesFactory _minesFactory;

        private MineConfig _installConfig;   // Const
        private MineConfig _explodeConfig;   // Instant

        private ClickMode _mode = ClickMode.None;

        public ClickService(
                MainHeroHolderService mainHeroHolder,
                IInputService inputService,
                MineConfig installConfig,
                MineConfig explodeConfig,
                MinesFactory minesFactory)
        {
            _camera = Camera.main;        
            _mainHeroHolder = mainHeroHolder;
            _inputService = inputService;  
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

            if (_mode == ClickMode.None) return;     

            MineConfig configToUse = _mode == ClickMode.InstallMines ? _installConfig : _explodeConfig;

            _minesFactory.Create(spawnPosition, configToUse);
        }

        public void SetConfigs(MineConfig install, MineConfig explode)
        {
            _installConfig = install;
            _explodeConfig = explode;
        }

        public void SetMode(ClickMode mode) => _mode = mode;


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
