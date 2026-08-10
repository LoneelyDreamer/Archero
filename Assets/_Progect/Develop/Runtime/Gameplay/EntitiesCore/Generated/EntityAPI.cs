namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider>();

		public global::UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(global::UnityEngine.CapsuleCollider value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask>();

		public global::UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(global::UnityEngine.LayerMask value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer ContactColliderBufferC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> ContactColliderBuffer => ContactColliderBufferC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactColliderBuffer(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

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

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath>();

		public global::System.Collections.Generic.List<global::UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath() { Value = new global::System.Collections.Generic.List<global::UnityEngine.Collider>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(global::System.Collections.Generic.List<global::UnityEngine.Collider> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanStartAttack => CanStartAttackC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest TakeDamegeRequestC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> TakeDamegeRequest => TakeDamegeRequestC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeRequest()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeRequest(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent TakeDamegeEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> TakeDamegeEvent => TakeDamegeEventC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeEvent()
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single>() }); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage CanApplayDamageC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanApplayDamage => CanApplayDamageC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplayDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage() {Value = value}); 
		}

		public Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public global::UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(global::UnityEngine.Rigidbody value)
		{
	return AddComponent (new Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

	}
}
