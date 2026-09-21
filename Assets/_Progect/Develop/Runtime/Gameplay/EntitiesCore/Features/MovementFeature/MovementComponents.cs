using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
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
    public class IsMoving : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }

    public class CanMove : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class RotationDirection : IEntityComponent
    {
        public ReactiveVeriable<Vector3> Value;
    }

    public class RotationSpeed : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class CanRotate : IEntityComponent
    {
        public ICompositCondition Value;
    }


}
