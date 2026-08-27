
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors
{
    public class BodyCollider : IEntityComponent
    {
        public CapsuleCollider Value;
    }

    public class ContactsDetectingMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class ContactColliderBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }
    public class ContactEntitiesBuffer : IEntityComponent
    {
        public Buffer<EntityLifeContext> Value;
    }

    public class DeathMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class IsTouchDeathMask : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    } 
    public class IsTouchAnotherTeam : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }

}
