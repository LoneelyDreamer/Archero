using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.SelfDetonation
{
    public class StartSelfDetonationRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class StartSelfDetonationEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class CanStartSelfDetonation : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class EndSelfDetonationEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class SelfDetonationProcessInitialTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class SelfDetonationProcessCurrentTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }
    public class SelfDetonationDelayEndEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InSelfDetonationProcess : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }

    public class AOEDamageRadius : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class AOEDamage : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

}
