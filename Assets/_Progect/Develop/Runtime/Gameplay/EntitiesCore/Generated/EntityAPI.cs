namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> MoveSpeed => MoveSpeedC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove CanMoveC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanMove => CanMoveC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> RotationSpeed => RotationSpeedC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate CanRotateC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanRotate => CanRotateC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> CurrentHealth => CurrentHealthC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth MaxHealthC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> MaxHealth => MaxHealthC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead IsDeadC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> IsDead => IsDeadC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie MustDieC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustDie => MustDieC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustSelfRelease => MustSelfReleaseC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess InDeadProcessC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> InDeadProcess => InDeadProcessC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public global::UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(global::UnityEngine.Rigidbody value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

	}
}
