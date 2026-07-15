using Assets._Progect.Develop.Runtime.Gameplay.Cupcha;
using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private GameplayInputArgs _mode;


        public override void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null, IInputSceneArgs sceneArgs2 = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not mathc with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            if (sceneArgs2 is not GameplayInputArgs gameplayInputArgs2)
                throw new ArgumentException($"{nameof(sceneArgs)} is not mathc with {typeof(GameplayInputArgs)} type");

            _mode = gameplayInputArgs2;

            GameplayContexRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Вы попали на уровень {_inputArgs.LevalNumber}");

            Debug.Log("Initialize Gameplay Scene");

            yield break;
        }

        private CupchaServisce _cupchaServisce;
        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");
            _cupchaServisce = _container.Resolve<CupchaServisce>();
            string cupchaText = _cupchaServisce.GanerateCupcha(_mode.LevalNumber);
            Debug.Log("Введите - " + cupchaText);
        }

        private string _currentText = string.Empty;

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
            //    ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            //    coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
            //}

            foreach (char c in Input.inputString)
            {
                if (c == '\b')
                {
                    if (_currentText.Length > 0)
                        _currentText = _currentText.Remove(_currentText.Length - 1);
                }
                else if (c == '\n' || c == '\r')
                {
                    Debug.Log("Введено " + _currentText);
                    if (_cupchaServisce.CupchaCheak(_currentText))
                    {
                        Debug.Log("Победа");
                        SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                        ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                        coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
                    }
                    else
                    {
                        Debug.Log("Поражение");
                        SceneSwitherService sceneSwitherService = _container.Resolve<SceneSwitherService>();
                        ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                        coroutinesPerformer.StartPerform(sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(1), new GameplayInputArgs(_mode.LevalNumber)));
                    }

                    _currentText = string.Empty;
                }
                else
                    _currentText += c;
            }
        }
    }
}
