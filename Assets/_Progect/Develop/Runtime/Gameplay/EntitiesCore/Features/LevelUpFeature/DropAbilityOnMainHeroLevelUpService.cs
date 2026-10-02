using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.View;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.PauseFeature;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature
{
    public class DropAbilityOnMainHeroLevelUpService : IInitializable, IDisposable
    {      
        private MainHeroHolderService _mainHeroHolderService;
        private GameplayPopupServise _popupServise;
        private ICoroutinesPerformer _coroutinesPerformer;
        private IPauseService _pauseService;

        private Queue<int> _LevelUpRequest = new();

        private AbilitySelectPopupPresentor _popup;
        private Coroutine _selectAbilirtProcess;

        private IDisposable _heroRegistredDisposable;
        private IDisposable _heroLevelChangedDisposable;

        public DropAbilityOnMainHeroLevelUpService(
            MainHeroHolderService mainHeroHolderService,
            GameplayPopupServise gameplayPopupServise,
            ICoroutinesPerformer coroutinesPerformer,
            IPauseService pauseService)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _popupServise = gameplayPopupServise;
            _coroutinesPerformer = coroutinesPerformer;
            _pauseService = pauseService;
        }

        private bool PopupIsOpened => _popup != null;

        public void Initialise()
        {
            _heroRegistredDisposable = _mainHeroHolderService.HeroRegistred.Subscribe(OnMainHeroRegistred);
        }

        public void Dispose()
        {
            _heroRegistredDisposable.Dispose();
            _heroLevelChangedDisposable.Dispose();
        }

        private void OnMainHeroRegistred(Entity hero)
        {
            _heroLevelChangedDisposable = hero.Level.Subscribe(OnHeroLevelChanged);
        }

        private void OnHeroLevelChanged(int arg1, int currentLevel)
        {
            _LevelUpRequest.Enqueue(currentLevel);

            if (_selectAbilirtProcess != null)
                return;

            _selectAbilirtProcess = _coroutinesPerformer.StartPerform(SelectAbilityProcess());
        }

        private IEnumerator SelectAbilityProcess()
        {

            while (_LevelUpRequest.Count > 0) 
            {
                int level = _LevelUpRequest.Dequeue();

                _pauseService.Pause();

                _popup = _popupServise.OpenAbilitySelectPopup(_mainHeroHolderService.MainHero, level, () =>
                {
                    _pauseService.Unpause();
                    _popup = null;
                });

                yield return new WaitUntil(() => PopupIsOpened == false);
            }

            _selectAbilirtProcess = null;
        }
    }
}
