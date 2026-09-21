using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature
{
    public class PreparationTrigerService
    {
        private ReactiveVeriable<bool> _hasMainHeroContact = new();

        private EntitiesFactory _entitiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;

        private Entity _nextStageTrigger;
        private Buffer<Entity> _nextStageTriggerContact;

        public PreparationTrigerService(
            EntitiesFactory entitiesFactory,
            EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesFactory = entitiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyVeriable<bool> HasMainHeroContact => _hasMainHeroContact;

        public void Create(Vector3 position)
        {
            if (_nextStageTrigger != null)
                throw new InvalidOperationException("Trigger already created");

            _nextStageTrigger = _entitiesFactory.CreateContactTrigger(position);
            _nextStageTriggerContact = _nextStageTrigger.ContactEntitiesBuffer;
        }

        public void Update(float deltaTime)
        {
            if (_nextStageTrigger == null)
                return;

            for (int i = 0; i < _nextStageTriggerContact.Count; i++)
            {
                Entity contact = _nextStageTriggerContact.Items[i];

                if(contact.HasComponent<IsMainHero>())
                {
                    _hasMainHeroContact.Value = true;
                    return;
                }
            }

            _hasMainHeroContact.Value = false;
        }

        public void Cleanup()
        {
            _entitiesLifeContext.Relese(_nextStageTrigger);
            _hasMainHeroContact.Value = false;
            _nextStageTrigger = null;
            _nextStageTriggerContact = null;    
        }
    }
}
