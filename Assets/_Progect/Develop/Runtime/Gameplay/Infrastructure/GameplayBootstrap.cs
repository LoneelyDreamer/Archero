using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.States;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;

        private GameplayStatesContext _gameplayStatesContext;
        private EntitiesLifeContext _entitiesLifeContext;
        private AIBrainContex _brainContex;
        private Entity _mainHero;
        private ClickService _clickService;

        //private GameplayInputArgs _mode;
        //private GameplayPopupServise _popupServise;
        public override void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not mathc with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            //if (sceneArgs2 is not GameplayInputArgs gameplayInputArgs2)
            //    throw new ArgumentException($"{nameof(sceneArgs)} is not mathc with {typeof(GameplayInputArgs)} type");

            //_mode = gameplayInputArgs2;

            GameplayContexRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Вы попали на уровень {_inputArgs.LevalNumber}");

            Debug.Log("Initialize Gameplay Scene");
            //_popupServise = _container.Resolve<GameplayPopupServise>();

            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainContex = _container.Resolve<AIBrainContex>();

            _mainHero = _container.Resolve<MainHeroFactory>().Create(Vector3.zero);

            _clickService = _container.Resolve<ClickService>();

            yield break;
        }
      
        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");

            _gameplayStatesContext.Run();
           // _popupServise.OpenCupchaPopup(_mode.LevalNumber);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("_mainHero.CurrentHealth.Value = " + _mainHero.CurrentHealth.Value);                
            }

            _brainContex?.Update(Time.deltaTime);
            _entitiesLifeContext?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);
            _clickService?.Update();

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
            }
        }        
    }
}
