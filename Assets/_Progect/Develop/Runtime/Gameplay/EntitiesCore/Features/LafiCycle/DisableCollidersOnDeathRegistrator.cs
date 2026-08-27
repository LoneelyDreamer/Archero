using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class DisableCollidersOnDeathRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private List<Collider> _colliders;
        public override void Register(EntityLifeContext entity)
        {
            entity.AddDisableCollidersOnDeath(_colliders);
        }
    }
}
