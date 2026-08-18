using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI
{
    public class StateMashineBrain : IBrain
    {
        private AIStateMashine _stateMashine;

        private bool _isEnabled;

        public StateMashineBrain(AIStateMashine stateMashine)
        {
            _stateMashine = stateMashine;
        }

        public void Disable()
        {
            _stateMashine.Exsit();
            _isEnabled = false;
        }

        public void Dispose()
        {
            _stateMashine.Dispose();
            _isEnabled = false;
        }

        public void Enable()
        {
            _stateMashine.Enter();
            _isEnabled = true;
        }

        public void Update(float deltaTime)
        {
            if (_isEnabled == false)
                return;

            _stateMashine.Update(deltaTime);
        }
    }
}
