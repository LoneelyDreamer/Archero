using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.PauseFeature;
using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Meta.Feathers.LevelsProgression;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.UI.Wallet;
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
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly WalletServise _walletServise;
        private readonly MainHeroHolderService _mainHeroHolderService;

        private readonly GameplayPopupServise _popupServise;

        public WinState(
            IInputService inputService,
            LevelsProgressionServise levelsProgressionServise,
            GameplayInputArgs gameplayInputArgs,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            IPauseService pauseService,
            GameplayPopupServise gameplayPopupServise,
            WalletServise walletServise,
            MainHeroHolderService mainHeroHolderService) : base(inputService, pauseService)
        {
            _levelsProgressionServise = levelsProgressionServise;
            _gameplayInputArgs = gameplayInputArgs;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _popupServise = gameplayPopupServise;
            _walletServise = walletServise;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Victory");

            _walletServise.Add(CurrenceTypes.Gold, _mainHeroHolderService.MainHero.Coins.Value);

            _levelsProgressionServise.AddLevelToCompleted(_gameplayInputArgs.LevalNumber);

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _popupServise.OpenWinPopup();
        }

        public void Update(float deltaTime)
        {
           
        }
    }
}
