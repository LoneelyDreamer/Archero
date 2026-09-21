using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors
{
    public class BodyContactEntitiesSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntites;

        private readonly CollidersRegestryService _collidersRegestryService;

        public BodyContactEntitiesSystem(CollidersRegestryService collidersRegestryService)
        {
            _collidersRegestryService = collidersRegestryService;
        }

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactColliderBuffer;
            _contactsEntites = entity.ContactEntitiesBuffer;
        }

        public void OnUpdate(float deltaTime)
        {
            _contactsEntites.Count = 0;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Collider collider = _contacts.Items[i];

                Entity contactEntity = _collidersRegestryService.GetBy(collider);

                if (contactEntity != null)
                {
                    _contactsEntites.Items[_contactsEntites.Count] = contactEntity;
                    _contactsEntites.Count++;
                }
            }
        }
    }
}
