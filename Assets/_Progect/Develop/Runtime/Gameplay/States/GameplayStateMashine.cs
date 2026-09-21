using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class GameplayStateMashine : StateMachine<IUpdatableState>
    {
        public GameplayStateMashine(List<IDisposable> disposables) : base(disposables)
        {
        }

        public GameplayStateMashine() : base(new List<IDisposable>())
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            CurrentState?.Update(deltaTime);
        }
    }
}
