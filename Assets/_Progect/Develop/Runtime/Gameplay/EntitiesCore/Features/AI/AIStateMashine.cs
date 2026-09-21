using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI
{
    public class AIStateMashine : StateMachine<IUpdatableState>
    {
        public AIStateMashine(List<IDisposable> disposables) : base(disposables)
        {
        }

        public AIStateMashine() : base(new List<IDisposable>())
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            CurrentState?.Update(deltaTime);
        }
    }
}
