using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class AbilitiesDirectionsShootAbilty : Ability, IDisposable
    {
        private AditionalDirectionsShootAbilityConfig _config;
        private Entity _entity;

        private IDisposable _currentLevelChangedDisposable;

        public AbilitiesDirectionsShootAbilty(
            AditionalDirectionsShootAbilityConfig config,
            Entity entity,
            int currentLevel) : base(config.ID, currentLevel, config.MaxLevel)
        {
            _config = config;
            _entity = entity;
        }

        public override void Actvate()
        {
            for (int i = 0; i < CurrentLevel.Value; i++)
            {
                AddShotDirectionsBy(i + 1);
            }

            _currentLevelChangedDisposable = CurrentLevel.Subscribe(OnCurrentLevelChanged);
        }

        private void OnCurrentLevelChanged(int previousLevel, int nextLevel)
        {
            for (int i = previousLevel; i < nextLevel; i++)
            {
                AddShotDirectionsBy(i + 1);
            }
        }

        public void Dispose()
        {
            _currentLevelChangedDisposable.Dispose();
        }

        private void AddShotDirectionsBy(int level)
        {
            List<DirectionShootConfig> directionShootConfigs = _config.GetBy(level);

            InstantShootingDirectionArgs shootingArgs = _entity.InstantShootingDirections;

            foreach (var directionShootConfig in directionShootConfigs)
            {
                shootingArgs.Add(new InstantShootDirectionArgs(directionShootConfig.Angel, directionShootConfig.NumberOfProjectiles));
            }

        }
    }
}
