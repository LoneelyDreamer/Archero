
using Assets._Progect.Develop.Runtime.Utillitles;
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
        public Buffer<Entity> Value;
    }


}
