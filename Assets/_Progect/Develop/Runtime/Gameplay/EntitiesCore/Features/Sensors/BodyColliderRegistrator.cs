using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors
{
    public class BodyColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private CapsuleCollider _body;
        public override void Register(Entity entity)
        {
            entity.AddBodyCollider(_body);
        }
    }


}
