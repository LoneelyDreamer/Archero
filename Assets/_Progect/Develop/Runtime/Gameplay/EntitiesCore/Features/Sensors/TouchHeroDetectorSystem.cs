using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors
{
    public class TouchHeroDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contacts;
        private ReactiveVeriable<bool> _isTouchHero;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _isTouchHero = entity.IsTouchHero;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contact = _contacts.Items[i];

                if (contact.TryGetTeam(out ReactiveVeriable<Teams> anotherTeam))
                {
                    if(anotherTeam.Value == Teams.MainHero)
                    {
                        _isTouchHero.Value = true;
                        return;
                    }                   
                }
            }

            _isTouchHero.Value = false;
        }
    }
}

