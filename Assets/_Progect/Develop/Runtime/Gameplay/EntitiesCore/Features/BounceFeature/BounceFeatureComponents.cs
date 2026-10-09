using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.BounceFeature
{
    public class LayerToBounceReaction : IEntityComponent
    {
        public LayerMask Value;
    }

    public class BounceEvent : IEntityComponent
    {
        public ReactiveEvent<RaycastHit> Value;
    }

    public class BounceCount : IEntityComponent
    {
        public ReactiveVeriable<int> Value;
    
    }



}
