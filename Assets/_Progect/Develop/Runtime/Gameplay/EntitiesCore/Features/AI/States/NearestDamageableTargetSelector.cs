using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public class NearestDamageableTargetSelector : ITargetSelector
    {
        private Entity _sourse;
        private Transform _sourseTransform;

        public NearestDamageableTargetSelector(Entity entity)
        {
            _sourse = entity;
            _sourseTransform = entity.Transform;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                return false;
            });

            return null;
        }
    }
}
