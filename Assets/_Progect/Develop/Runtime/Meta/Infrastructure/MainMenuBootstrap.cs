using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private WalletServise _walletServise;

        public override void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContexRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initialize MainMenu Scene");

            _walletServise =_container.Resolve<WalletServise>();

            yield break;
        }

        public override void Run()
        {
            Debug.Log("Start MainMenu Scene");            
        }
       

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(2)));
            }

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _walletServise.Add(CurrenceTypes.Gold, 10);
                Debug.Log("Current gold" + _walletServise.GetCurrence(CurrenceTypes.Gold).Value);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(_walletServise.Enough(CurrenceTypes.Gold, 10))
                {
                    _walletServise.Spend(CurrenceTypes.Gold, 10);
                    Debug.Log("Current gold" + _walletServise.GetCurrence(CurrenceTypes.Gold).Value);
                }      
            }

        }
    }
}
