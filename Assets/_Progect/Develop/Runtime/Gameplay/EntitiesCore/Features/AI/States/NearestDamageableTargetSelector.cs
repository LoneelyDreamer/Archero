using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
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
        private EntityLifeContext _sourse;
        private Transform _sourseTransform;

        public NearestDamageableTargetSelector(EntityLifeContext entity)
        {
            _sourse = entity;
            _sourseTransform = entity.Transform;
        }

        public EntityLifeContext SelectTargetFrom(IEnumerable<EntityLifeContext> targets)
        {
            IEnumerable<EntityLifeContext> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<TakeDamegeRequest>();

                if(target.TryGetCanApplayDamage(out ICompositCondition canApplyDamage))
                {
                    result = result && canApplyDamage.Evaluate();
                }

                if(_sourse.TryGetTeam(out ReactiveVeriable<Teams> sourceTeam) 
                && target.TryGetTeam(out ReactiveVeriable<Teams> targetTeam))
                {
                    result = result && (sourceTeam.Value != targetTeam.Value);
                }

                result = result && (target != _sourse);

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            EntityLifeContext closestTarget = selectedTargets.First();
            float minDistance = GetDistanceTo(closestTarget);

            foreach (EntityLifeContext target in selectedTargets)
            {
                float distance = GetDistanceTo(target);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target;
                }
            }
            return closestTarget;
        }

        private float GetDistanceTo(EntityLifeContext target) => (_sourseTransform.position - target.Transform.position).magnitude;
    }
}
