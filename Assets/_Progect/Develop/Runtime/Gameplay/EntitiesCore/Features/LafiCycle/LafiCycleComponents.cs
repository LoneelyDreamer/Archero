using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class CurrentHealth : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }  

    public class MaxHealth : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class IsDead : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }

    public class MustDie : IEntityComponent
    {
        public ICompositCondition Value;
    }
    public class MustSelfRelease : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class DeathProcessInitialTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class DeathProcessCurrentTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class InDeadProcess : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }
}
