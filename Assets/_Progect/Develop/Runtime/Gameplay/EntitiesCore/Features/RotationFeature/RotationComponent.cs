using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.RotationFeature
{
    public class RotationSpeed : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }
}
