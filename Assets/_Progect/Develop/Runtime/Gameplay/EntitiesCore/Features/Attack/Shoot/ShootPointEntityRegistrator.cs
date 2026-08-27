using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot
{
    public class ShootPointEntityRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _shootPoint;
        public override void Register(EntityLifeContext entity)
        {
            entity.AddShootPoint(_shootPoint);
        }
    }
}
