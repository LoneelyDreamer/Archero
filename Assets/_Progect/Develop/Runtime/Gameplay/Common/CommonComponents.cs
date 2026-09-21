using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Common
{
    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value;
    }

    public class TransformComponent : IEntityComponent
    {
        public Transform Value;
    }

}
