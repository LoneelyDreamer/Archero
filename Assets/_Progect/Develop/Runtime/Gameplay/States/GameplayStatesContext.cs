using System;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class GameplayStatesContext : IDisposable
    {
        private GameplayStateMashine _gameplayStateMashine;

        private bool _isRunning;
        public GameplayStatesContext(GameplayStateMashine gameplayStateMashine)
        {
            _gameplayStateMashine = gameplayStateMashine;
        }

        public void Run()
        {
            _gameplayStateMashine.Enter();
            _isRunning = true;
        }

        public void Update(float deltaTime)
        {
            if(_isRunning == false)
                return;

            _gameplayStateMashine.Update(deltaTime);
        }

        public void Dispose()
        {
            _isRunning = false;
            _gameplayStateMashine.Dispose();
        }
    }
}
