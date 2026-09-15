using Assets._Progect.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.LevelsProgression;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Shop;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.UI.WinAndLoseCaunters;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

namespace Assets._Progect.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresentor : IPresentor
    {
        private readonly MainMenuScreenView _screen;

        private readonly ProjectPresentorFactory _projectPresentorFactory;

        private readonly MainMenuPopupServise _popupServise;

        private readonly SceneSwitherService _sceneSwitherService;

        private readonly LevelsProgressionServise _levelsServise;

        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly ShopServise _shopServise;

        private readonly ConfigsProviderServise _configsProviderServise;

        private readonly List<IPresentor> _childPresenters = new();

        public MainMenuScreenPresentor(
            MainMenuScreenView screen,
            ProjectPresentorFactory projectPresentorFactory,
            MainMenuPopupServise popupServise,
            ShopServise shopServise,
            ICoroutinesPerformer coroutinesPerformer,
            LevelsProgressionServise levelsServise,
            SceneSwitherService sceneSwitherService,
            ConfigsProviderServise configsProviderServise)
        {
            _screen = screen;
            _projectPresentorFactory = projectPresentorFactory;
            _popupServise = popupServise;
            _shopServise = shopServise;
            _coroutinesPerformer = coroutinesPerformer;
            _levelsServise = levelsServise;
            _sceneSwitherService = sceneSwitherService;
            _configsProviderServise = configsProviderServise;
        }

        public void Initialise()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            _screen.OpenRundomLevelButtonClicked += OnOpenRundomLevelButtonClicked;
            _screen.ResetRateButtoClicked += ResetRateButtoClicked;

            CreateWallet();
            CreateWinAndLoseCaunter();

            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();
        }      

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;
            _screen.ResetRateButtoClicked -= ResetRateButtoClicked;

            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresentor walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_screen.WalletView);

            _childPresenters.Add(walletPresentor);
        }

        private void CreateWinAndLoseCaunter()
        {
            WinAndLoseCauntersPresentor winAndLoseCauntersPresentor = _projectPresentorFactory
                .CreateWinAndLoseCauntersPresentor(_screen.RateView);

            _childPresenters.Add(winAndLoseCauntersPresentor);
        }

        private void OnOpenLevelsMenuButtonClicked()
        {
            _popupServise.OpenLevelsMenuPopup();
        }

        private void ResetRateButtoClicked()
        {
            _shopServise.BuyCountersReset();
        }

        //private void OnOpenRundomLevelButtonClicked()
        //{
        //    int levelsCount = _levelsServise.CompletedLevelsCount;

        //    int rundom = Random.Range(0, levelsCount);

        //    if (_levelsServise.CanPlay(rundom) == false)
        //    {
        //        Debug.Log("Уровень заблокирован, пройдите предыдущий");
        //        return;
        //    }        

        //    _coroutinesPerformer
        //    .StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(rundom)));
        //}

        private void OnOpenRundomLevelButtonClicked()
        {
            LevelsListConfig config = _configsProviderServise.GetConfig<LevelsListConfig>();
            int totalLevels = config.Levels.Count;

            if (totalLevels == 0)
            {
                Debug.LogWarning("В конфиге нет уровней");
                return;
            }

            int randomLevel = Random.Range(1, totalLevels + 1); // 1-based inclusive

            _coroutinesPerformer.StartPerform(
                _sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(randomLevel)));
        }

    }
}
