using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage
{
    public class DealDamageOnContactSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contacts;
        private ReactiveVeriable<float> _damage;

        private List<Entity> _processedEntities;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _damage = entity.BodyContactDamage;

            _processedEntities = new List<Entity>(_contacts.Items.Length);
        }

        public void OnUpdate(float deltaTime)
        {
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

        public bool ContainInContacts(Entity entity)
        {
            for (int i = 0; i < _contacts.Count; i++)
                if(_contacts.Items[i] == entity)
                    return true;

            return false; 
        }
    }
}
