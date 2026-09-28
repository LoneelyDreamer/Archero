using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle
{
    public class HealthBarPointRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _point;
        public override void Register(Entity entity)
        {
            entity.AddHealthBarPoint(_point);
        }
    }
}
