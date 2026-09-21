using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Meta.Feathers.LevelsProgression;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelTilePresentor : IPresentor, ISubscribePresentor
    {
        private readonly LevelsProgressionServise _levelsServise;
        private readonly SceneSwitherService _sceneSwitherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly int _levelNumber;

        private readonly LevelTileView _view;

        public LevelTilePresentor(
            LevelsProgressionServise levelsServise,
            SceneSwitherService sceneSwitherService,
            ICoroutinesPerformer coroutinesPerformer, 
            int levelNumber,
            LevelTileView view)
        {
            _levelsServise = levelsServise;
            _sceneSwitherService = sceneSwitherService;
            _coroutinesPerformer = coroutinesPerformer;
            _levelNumber = levelNumber;
            _view = view;
        }

        public LevelTileView View => _view;

        public void Initialise()
        {
            _view.SetLevel(_levelNumber.ToString());

            if (_levelsServise.CanPlay(_levelNumber))
            {
                if (_levelsServise.IsLevelCompleted(_levelNumber))
                    _view.SetComplete();
                else
                    _view.SetActive();
            }
            else
            {
                _view.SetBlock();
            }           
        }

        public void Dispose()
        {
            _view.Clicked -= OnViewClicked;
        }
        private void OnViewClicked()
        {
            if(_levelsServise.CanPlay(_levelNumber) == false)
            {
                Debug.Log("Уровень заблокирован, пройдите предыдущий");
                return;
            }

            _coroutinesPerformer
                .StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(_levelNumber)));
        }

        public void Subscribe()
        {
            _view.Clicked += OnViewClicked;
        }

        public void Unsubscribe()
        {
            _view.Clicked -= OnViewClicked;
        }
    }
}
