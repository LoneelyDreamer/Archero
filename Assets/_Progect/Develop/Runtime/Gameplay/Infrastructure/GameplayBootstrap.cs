using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
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

        [SerializeField] private TestGameplay _testGameplay;
        private EntitiesLifeContext _entitiesLifeContext;

        public override void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not mathc with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContexRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Вы попали на уровень {_inputArgs.LevalNumber}");

            Debug.Log("Initialize Gameplay Scene");

            _testGameplay.Initialze(_container);

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();

            yield break;
        }


        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");

            _testGameplay.Run();
        }

        private void Update()
        {
            _entitiesLifeContext?.Update(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
            }
        }
    }
}
