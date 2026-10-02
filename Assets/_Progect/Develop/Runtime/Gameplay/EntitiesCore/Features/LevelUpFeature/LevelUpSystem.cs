using Assets._Progect.Develop.Runtime.Configs.Gameplay;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature
{
    public class LevelUpSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<float> _experience;
        private ReactiveVeriable<int> _level;
        private ExperienceForUpgradeLevelConfig _config;

        private IDisposable _experenceChangedDisposable;

        public LevelUpSystem(ExperienceForUpgradeLevelConfig config)
        {
            _config = config;
        }

        public float CurrentLimitForExp => _config.GetExpirienceFor(_level.Value);

        public void OnInit(Entity entity)
        {
            _experience = entity.Experience;
            _level = entity.Level;

            _experenceChangedDisposable = _experience.Subscribe(OnExperienceChanged);
        }

        private void OnExperienceChanged(float arg1, float newExp)
        {
            while (newExp >= CurrentLimitForExp && _level.Value < _config.MaxLevel)
            {
                newExp -= CurrentLimitForExp;
                _level.Value++; 
            }

            _experience.Value = newExp;
        }

        public void OnDispose()
        {
            _experenceChangedDisposable.Dispose();
        }

       
    }
}
