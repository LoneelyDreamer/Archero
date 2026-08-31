using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage;
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
    public class NearestMinHpInTeleportRadiusTargetSelector : ITargetSelector
    {
        private Entity _sourse;
        private Transform _sourseTransform;
        private ReactiveVeriable<float> _teleportRadius;

        public NearestMinHpInTeleportRadiusTargetSelector(Entity entity)
        {
            _sourse = entity;
            _sourseTransform = entity.Transform;
            _teleportRadius = entity.TeleportRadius;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<TakeDamegeRequest>();

                if (target.TryGetCanApplayDamage(out ICompositCondition canApplyDamage))
                {
                    result = result && canApplyDamage.Evaluate();
                }

                result = result && (GetDistanceTo(target) <= _teleportRadius.Value);

                result = result && (target != _sourse);

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            Entity priorityTarget = selectedTargets.First();

            float minHpTarget = priorityTarget.CurrentHealth.Value;

            foreach (Entity target in selectedTargets)
            {
                float targetHp = target.CurrentHealth.Value;

                if (targetHp < minHpTarget)
                {
                    minHpTarget = targetHp;
                    priorityTarget = target;
                }
            }
            return priorityTarget;
        }

        private float GetDistanceTo(Entity target) => (_sourseTransform.position - target.Transform.position).magnitude;
    }
}
