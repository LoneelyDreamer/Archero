using Assets._Progect.Develop.Runtime.Configs.Gameplay;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.Exsperience
{
    public class MainHeroExsperiencePresentor : IPresentor
    {
        private BarWithText _view;

        private MainHeroHolderService _mainHeroHolderService;
        private ExperienceForUpgradeLevelConfig _levelUpconfig;
        private ReactiveVeriable<float> _experience;
        private ReactiveVeriable<int> _currentLevel;

        private List<IDisposable> _disposables = new();

        public MainHeroExsperiencePresentor(
            BarWithText view,
            MainHeroHolderService heroHolderService,
            ExperienceForUpgradeLevelConfig levelUpconfig)
        {
            _view = view;
            _mainHeroHolderService = heroHolderService;
            _levelUpconfig = levelUpconfig;
        }

        public void Initialise()
        {
            _disposables.Add(_mainHeroHolderService.HeroRegistred.Subscribe(OnMainHeroRegistred));
        }

        private void OnMainHeroRegistred(Entity entity)
        {
            _experience = entity.Experience;
            _currentLevel = entity.Level;

            _disposables.Add(_experience.Subscribe(OnCurrentExperieceChanged));
            _disposables.Add(_currentLevel.Subscribe(OnLevelChanged));

            UpdateBarText(_currentLevel.Value);
            UpdateCurrentExperience(_experience.Value);
        }


        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void UpdateCurrentExperience(float value)
            => _view.UpdateSlider(value / _levelUpconfig.GetExpirienceFor(_currentLevel.Value));

        private void UpdateBarText(int level) => _view.UpdateText($"Lv.{level}");


        private void OnLevelChanged(int arg1, int arg2)
            => UpdateBarText(_currentLevel.Value);

        private void OnCurrentExperieceChanged(float arg1, float arg2)
            => UpdateCurrentExperience(_experience.Value);




    }
}
