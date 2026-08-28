using UnityEngine;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team TeamC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out ReactiveVeriable<Teams> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<Teams>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider>();

		public global::UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out CapsuleCollider value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider component);
			if (result)
				value = component.Value;
			else
				value = default(CapsuleCollider);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(global::UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask>();

		public global::UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask component);
			if (result)
				value = component.Value;
			else
				value = default(LayerMask);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(global::UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer ContactColliderBufferC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> ContactColliderBuffer => ContactColliderBufferC.Value;

		public bool TryGetContactColliderBuffer(out Buffer<Collider> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer component);
			if (result)
				value = component.Value;
			else
				value = default(Buffer<Collider>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactColliderBuffer(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out Buffer<Entity> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer component);
			if (result)
				value = component.Value;
			else
				value = default(Buffer<Entity>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask DeathMaskC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask>();

		public global::UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask component);
			if (result)
				value = component.Value;
			else
				value = default(LayerMask);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(global::UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out ReactiveVeriable<Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<Vector3>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving IsMovingC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove CanMoveC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out ReactiveVeriable<Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<Vector3>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate CanRotateC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero.IsMainHero IsMainHeroC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero.IsMainHero>();

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth MaxHealthC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead IsDeadC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie MustDieC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess InDeadProcessC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> InDeadProcess => InDeadProcessC.Value;

		public bool TryGetInDeadProcess(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath>();

		public global::System.Collections.Generic.List<global::UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out List<Collider> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath component);
			if (result)
				value = component.Value;
			else
				value = default(List<Collider>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath() { Value = new global::System.Collections.Generic.List<global::UnityEngine.Collider>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(global::System.Collections.Generic.List<global::UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint ShootPointC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint>();

		public global::UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out Transform value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint component);
			if (result)
				value = component.Value;
			else
				value = default(Transform);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(global::UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack MustCanselAttackC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustCanselAttack => MustCanselAttackC.Value;

		public bool TryGetMustCanselAttack(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCanselAttack(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent AttackCanseledEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent AttackCanseledEvent => AttackCanseledEventC.Value;

		public bool TryGetAttackCanseledEvent(out ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanseledEvent()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanseledEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime(out ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::System.Boolean> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest TakeDamegeRequestC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> TakeDamegeRequest => TakeDamegeRequestC.Value;

		public bool TryGetTakeDamegeRequest(out ReactiveEvent<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeRequest()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeRequest(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent TakeDamegeEventC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> TakeDamegeEvent => TakeDamegeEventC.Value;

		public bool TryGetTakeDamegeEvent(out ReactiveEvent<float> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveEvent<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeEvent()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<global::System.Single> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage CanApplayDamageC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanApplayDamage => CanApplayDamageC.Value;

		public bool TryGetCanApplayDamage(out ICompositCondition value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage component);
			if (result)
				value = component.Value;
			else
				value = default(ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplayDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget CurrentTargetC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out ReactiveVeriable<Entity> value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget component);
			if (result)
				value = component.Value;
			else
				value = default(ReactiveVeriable<Entity>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public global::UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out Rigidbody value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if (result)
				value = component.Value;
			else
				value = default(Rigidbody);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(global::UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent() { Value = value });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public global::UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out Transform value)
		{
			bool result = TryGetComponent(out Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent component);
			if (result)
				value = component.Value;
			else
				value = default(Transform);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(global::UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent() { Value = value });
		}

	}
}
