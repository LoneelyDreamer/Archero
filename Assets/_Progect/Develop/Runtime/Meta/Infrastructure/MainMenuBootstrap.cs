using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private ReactiveVeriable<int> _field;

        private int _gameMode;

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

            _field = new ReactiveVeriable<int>(5);
            _field.Subscribe(OnFieldChanged);

            ConfigsProviderServise configsProviderServise = _container.Resolve<ConfigsProviderServise>();
            GameModeConfig config = configsProviderServise.GetConfig<GameModeConfig>();          
        }

        private void OnFieldChanged(int arg1, int arg2)
        {
            Debug.Log($"Field changed old -{arg1} new -{arg2}");
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
            //    ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            //    coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(2)));
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _field.Value++;
            }

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
        }
    }
}
