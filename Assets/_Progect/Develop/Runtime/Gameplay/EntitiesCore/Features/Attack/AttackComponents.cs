using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack
{
    public class StartAttackRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class StartAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class CanStartAttack : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class EndAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class AttackProcessInitialTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class AttackProcessCurrentTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class InAttackProcess : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }


    public class AttackDelayTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class AttackDelayEndEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InstantAttackDamage : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    } 
    public class ShootPoint : IEntityComponent
    {
        public Transform Value;
    }

    public class MustCanselAttack : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class AttackCanseledEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class AttackCooldownInitialTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class AttackCooldownCurrentTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class InAttackCooldown : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }
}
