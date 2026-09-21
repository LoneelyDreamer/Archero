using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Meta.Feathers.LevelsProgression;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class WinState : EndGameState, IUpdatableState
    {
        private readonly LevelsProgressionServise _levelsProgressionServise;
        private readonly GameplayInputArgs _gameplayInputArgs;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly SceneSwitherService _sceneSwitherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public WinState(
            IInputService inputService,
            LevelsProgressionServise levelsProgressionServise,
            GameplayInputArgs gameplayInputArgs,
            PlayerDataProvider playerDataProvider,
            SceneSwitherService sceneSwitherService,
            ICoroutinesPerformer coroutinesPerformer) : base(inputService)
        {
            _levelsProgressionServise = levelsProgressionServise;
            _gameplayInputArgs = gameplayInputArgs;
            _playerDataProvider = playerDataProvider;
            _sceneSwitherService = sceneSwitherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Victory");

            _levelsProgressionServise.AddLevelToCompleted(_gameplayInputArgs.LevalNumber);

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());  
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
            }
        }
    }
}
