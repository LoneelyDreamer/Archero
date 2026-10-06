using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay.Exsperience;
using Assets._Progect.Develop.Runtime.UI.Gameplay.HealthDisplay;
using Assets._Progect.Develop.Runtime.UI.Gameplay.Stages;
using Assets._Progect.Develop.Runtime.UI.MainMenu;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresentor
    {
        private readonly GameplayScreenView _screen;
        private readonly GameplayPresentorFactory _gameplayPresentorFactory;
        private readonly ProjectPresentorFactory _projectPresentorFactory;

        private readonly List<IPresentor> _childPresenters = new();

        private EntitiesHealthDispleyPresentor _healthDispleyPresentor;

        private readonly MainHeroHolderService _mainHeroHolderService;
        private IDisposable _mainHeroHolderServiceDisposable;
        private CurrencyPresentor _mainHeroCoinsPresentor;

        public GameplayScreenPresenter(GameplayScreenView screen,
            GameplayPresentorFactory gameplayPresentorFactory,
            ProjectPresentorFactory projectPresentorFactory,
            MainHeroHolderService mainHeroHolderService)
        {
            _screen = screen;
            _gameplayPresentorFactory = gameplayPresentorFactory;
            _projectPresentorFactory = projectPresentorFactory;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public void Initialise()
        {
            CreateStageNumber();
            CreateEntitiesHealthDispleyPresentor();
            CreateMainHeroExsperiencePresentor();

            _mainHeroHolderServiceDisposable = _mainHeroHolderService.HeroRegistred.Subscribe(OnHeroRegistred);

            foreach (IPresentor presentor in _childPresenters)
                presentor.Initialise();         
        }     

        public void LateUpdate()
        {
            _healthDispleyPresentor.LateUpdate();
        }

        private void OnHeroRegistred(Entity entity)
        {
            _mainHeroCoinsPresentor = _projectPresentorFactory.CreateCurrencyPresentor(_screen.CoinsView, entity.Coins, Meta.Feathers.Wallet.CurrenceTypes.Gold);

            _mainHeroCoinsPresentor.Initialise();
        }

        private void CreateStageNumber()
        {
            StagePresenter stagePresenter = _gameplayPresentorFactory.CreateStagePresenter(_screen.StageNumberView);

            _childPresenters.Add(stagePresenter);
        }

        public void Dispose()
        {
            _mainHeroHolderServiceDisposable.Dispose();
            _mainHeroCoinsPresentor.Dispose();

            foreach (IPresentor presentor in _childPresenters)
                presentor.Dispose();

            _childPresenters.Clear();
        }

        private void CreateEntitiesHealthDispleyPresentor()
        {
            _healthDispleyPresentor = _gameplayPresentorFactory.CreateEntitiesHealthDispleyPresentor(_screen.EntitiesHealthDispley);

            _childPresenters.Add(_healthDispleyPresentor);
        }

        private void CreateMainHeroExsperiencePresentor()
        {
            MainHeroExsperiencePresentor mainHeroExsperiencePresentor = _gameplayPresentorFactory.CreateMainHeroExsperiencePresentor(_screen.ExpirienceBarView);

            _childPresenters.Add(mainHeroExsperiencePresentor);
        }
    }
}
