using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
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

    public class Owner : IEntityComponent
    {
        public ReactiveVeriable<Entity> Value;
    }

}
