using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.SelfDetonation
{
    public class InstantAOESystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVeriable<float> _damage;
        private ReactiveEvent _endSelfDetonationEvent;
        private Buffer<Entity> _contacts;
        private List<Entity> _processedEntities;
        private IDisposable _startTeleportDisposable;
        private Entity _entity;

        public void OnInit(Entity entity)
        {
            _entity = entity;

            _damage = entity.AOEDamage;
            _endSelfDetonationEvent = entity.EndSelfDetonationEvent;

            _contacts = entity.ContactEntitiesBuffer;
            _processedEntities = new List<Entity>(_contacts.Items.Length);
            _startTeleportDisposable = _endSelfDetonationEvent.Subscribe(OnSelfDetonate);
        }

        private void OnSelfDetonate()
        {
            Debug.Log("_contacts = " + _contacts.Count);

            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                if (_processedEntities.Contains(contactEntity) == false)
                {
                    _processedEntities.Add(contactEntity);

                    //if (contactEntity.HasComponent<TakeDamegeRequest>())
                    //    contactEntity.TakeDamegeRequest.Invoke(_damage.Value);

                    EntitiesHelper.TryTakeDamageFrom(_entity, contactEntity, _damage.Value);

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
