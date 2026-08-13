using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AOE
{
    public class InstantAOESystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<float> _damage;
        private ReactiveEvent _startTeleportEvent;
        private Buffer<Entity> _contacts;
        private List<Entity> _processedEntities;
        private IDisposable _startTeleportDisposable;

        public void OnInit(Entity entity)
        {
            _damage = entity.AOEDamage;
            _startTeleportEvent = entity.StartTeleportEvent;

            _contacts = entity.ContactEntitiesBuffer;
            _processedEntities = new List<Entity>(_contacts.Items.Length);

            _startTeleportDisposable = _startTeleportEvent.Subscribe(OnTeleportStarted);
        }

        private void OnTeleportStarted()
        {
            Debug.Log("_contacts = " + _contacts.Count);

            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                if (_processedEntities.Contains(contactEntity) == false)
                {
                    _processedEntities.Add(contactEntity);

                    if (contactEntity.HasComponent<TakeDamegeRequest>())
                        contactEntity.TakeDamegeRequest.Invoke(_damage.Value);
                }
            }

            for (int i = _processedEntities.Count - 1; i >= 0; i--)
                if (ContainInContacts(_processedEntities[i]) == false)
                    _processedEntities.RemoveAt(i);
        }

        public void OnDispose()
        {
            _startTeleportDisposable.Dispose();
        }

        public bool ContainInContacts(Entity entity)
        {
            for (int i = 0; i < _contacts.Count; i++)
                if (_contacts.Items[i] == entity)
                    return true;

            return false;
        }
    }
}
