using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature
{

    public class MoveDirection : IEntityComponent
    {
        public ReactiveVeriable<Vector3> Value;
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

 


}
