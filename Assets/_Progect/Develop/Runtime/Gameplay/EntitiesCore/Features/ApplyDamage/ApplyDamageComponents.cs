using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage
{
    public class TakeDamegeRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }

    public class TakeDamegeEvent : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }

    public class CanApplayDamage : IEntityComponent
    {
        public ICompositCondition Value;
    }


}
