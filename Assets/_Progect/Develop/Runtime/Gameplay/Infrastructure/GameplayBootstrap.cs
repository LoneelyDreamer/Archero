using Assets._Progect.Develop.Runtime.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private GameplayInputArgs _mode;
        private GameplayPopupServise _popupServise;
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
            _popupServise = _container.Resolve<GameplayPopupServise>();

            yield break;
        }
      
        public override void Run()
        {
            Debug.Log("Start Gameplay Scene");
            _popupServise.OpenCupchaPopup(_mode.LevalNumber);
        }

        private string _currentText = string.Empty;
        
    }
}
