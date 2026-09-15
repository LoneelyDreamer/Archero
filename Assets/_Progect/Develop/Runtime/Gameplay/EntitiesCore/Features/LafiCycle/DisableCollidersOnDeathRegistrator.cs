using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class DisableCollidersOnDeathRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private List<Collider> _colliders;
        public override void Register(Entity entity)
        {           

            if (_colliders == null || _colliders.Count == 0)
            {
                Debug.LogWarning($"[{nameof(DisableCollidersOnDeathRegistrator)}] На '{name}' не назначены _colliders", this);
                entity.AddDisableCollidersOnDeath(new List<Collider>());
                return;
            }

            entity.AddDisableCollidersOnDeath(_colliders);
        }
    }
}
