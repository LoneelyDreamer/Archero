using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System.Collections;
using UnityEngine;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Shop;

namespace Assets._Progect.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private PlayerDataProvider _playerDataProvider;
        private ICoroutinesPerformer _coroutinesPerformer;
        private WinAndLoseCauntersServise _winAndLoseCauntersServise;
        private WalletServise _walletServise;
        private ShopServise _shopServise;

        public override void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null, IInputSceneArgs sceneArgs2 = null)
        {
            _container = container;

            MainMenuContexRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initialize MainMenu Scene");

            _playerDataProvider = _container.Resolve<PlayerDataProvider>();
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            _winAndLoseCauntersServise = _container.Resolve<WinAndLoseCauntersServise>();
            _walletServise = _container.Resolve<WalletServise>();
            _shopServise = _container.Resolve<ShopServise>();

           

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Start MainMenu Scene");            
        }
       

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(2), new GameplayInputArgs(1)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(2), new GameplayInputArgs(2)));
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                Debug.Log("Save");
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Wins = " + _winAndLoseCauntersServise.GetCurrence(CauntersTypes.Wins).Value);
                Debug.Log("Looses = " + _winAndLoseCauntersServise.GetCurrence(CauntersTypes.Loses).Value);
            } 

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Gold = " + _walletServise.GetCurrence(CurrenceTypes.Gold).Value);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                _shopServise.BuyCountersReset();
            }

        }
    }
}
