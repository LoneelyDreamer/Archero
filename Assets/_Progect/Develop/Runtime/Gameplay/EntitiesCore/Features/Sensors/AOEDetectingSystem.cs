using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors
{
    public class AOEDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntites;
        private LayerMask _mask;
        private ReactiveEvent _startTeleportEvent;
        private ReactiveVeriable<float> _radiusAOE;

        private CapsuleCollider _body;

        private IDisposable _startTeleportDisposable;

        private readonly CollidersRegestryService _collidersRegestryService;

        public AOEDetectingSystem(CollidersRegestryService collidersRegestryService)
        {
            _collidersRegestryService = collidersRegestryService;
        }

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactColliderBuffer;
            _contactsEntites = entity.ContactEntitiesBuffer;
            _mask = entity.ContactsDetectingMask;
            _body = entity.BodyCollider;
            _radiusAOE = entity.AOEDamageRadius;
            _startTeleportEvent = entity.StartTeleportEvent;

            _startTeleportDisposable = _startTeleportEvent.Subscribe(OnTeleportStarted);
        }

        private void OnTeleportStarted()
        {
            _contacts.Count = Physics.OverlapCapsuleNonAlloc(
              _body.bounds.min,
              _body.bounds.max,
              _body.radius * _radiusAOE.Value,
              _contacts.Items,
              _mask,
              QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();

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

        public void OnDispose()
        {
            _startTeleportDisposable.Dispose();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                {
                    _contacts.Items[i] = _contacts.Items[i + 1];
                }

                _contacts.Count--;
            }
        }
    }
}
