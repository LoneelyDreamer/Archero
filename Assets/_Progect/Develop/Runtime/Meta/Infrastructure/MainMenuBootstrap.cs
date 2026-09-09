using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        public override void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null, IInputSceneArgs sceneArgs2 = null)
        {
            _container = container;

            MainMenuContexRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("Initialize MainMenu Scene");

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

            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
                Debug.Log("Save");
            }  

           
        }
    }
}
