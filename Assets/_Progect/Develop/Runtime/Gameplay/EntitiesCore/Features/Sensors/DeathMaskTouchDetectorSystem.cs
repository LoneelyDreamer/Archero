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
    public class DeathMaskTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private ReactiveVeriable<bool> _isTouchDeathMask;
        private LayerMask _deathMask;

        public void OnInit(EntityLifeContext entity)
        {
            _contacts = entity.ContactColliderBuffer;
            _isTouchDeathMask = entity.IsTouchDeathMask;
            _deathMask = entity.DeathMask;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (MatchWithDeathLayer(_contacts.Items[i]))
                {
                    _isTouchDeathMask.Value = true;
                    return;
                }
            }

            _isTouchDeathMask.Value = false;
        }

        private bool MatchWithDeathLayer(Collider collider)
        {
            return ((1 <<  collider.gameObject.layer) & _deathMask) != 0;
        }
    }
}
