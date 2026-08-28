using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors
{
    public class AnotherTeamTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Entity> _contacts;
        private ReactiveVeriable<bool> _isTouchAnotherTeam;
        private ReactiveVeriable<Teams> _sourceTeam;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactEntitiesBuffer;
            _isTouchAnotherTeam = entity.IsTouchAnotherTeam;
            _sourceTeam = entity.Team;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contact = _contacts.Items[i];

                if (contact.TryGetTeam(out ReactiveVeriable<Teams> anotherTeam))
                {
                    if(_sourceTeam.Value != anotherTeam.Value)
                    {
                        _isTouchAnotherTeam.Value = true;
                        return;
                    }
                }
            }

            _isTouchAnotherTeam.Value = false;
        }
    }
}
