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
		public global::Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public global::UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out global::UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.Rigidbody);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(global::UnityEngine.Rigidbody value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.Common.RigidbodyComponent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public global::UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out global::UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.Transform);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(global::UnityEngine.Transform value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.Common.TransformComponent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget CurrentTargetC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.CurrentTarget() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesComponent AbilitiesC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesComponent>();

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesList Abilities => AbilitiesC.Value;

		public bool TryGetAbilities(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesList value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesComponent component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesList);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilities()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesComponent() { Value = new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesList() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilities(global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesList value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.AbilitiesComponent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage CanApplayDamageC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanApplayDamage => CanApplayDamageC.Value;

		public bool TryGetCanApplayDamage(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplayDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.CanApplayDamage() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent TakeDamegeEventC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float> TakeDamegeEvent => TakeDamegeEventC.Value;

		public bool TryGetTakeDamegeEvent(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeEvent()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeEvent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest TakeDamegeRequestC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float> TakeDamegeRequest => TakeDamegeRequestC.Value;

		public bool TryGetTakeDamegeRequest(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeRequest()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamegeRequest(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ApplyDamage.TakeDamegeRequest() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent AttackCanseledEventC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent AttackCanseledEvent => AttackCanseledEventC.Value;

		public bool TryGetAttackCanseledEvent(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanseledEvent()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCanseledEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCanseledEvent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownCurrentTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackCooldownInitialTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayEndEvent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackDelayTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessCurrentTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.AttackProcessInitialTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.CanStartAttack() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.EndAttackEvent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackCooldown() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InAttackProcess() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.InstantAttackDamage() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack MustCanselAttackC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustCanselAttack => MustCanselAttackC.Value;

		public bool TryGetMustCanselAttack(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCanselAttack(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.MustCanselAttack() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint ShootPointC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint>();

		public global::UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out global::UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.Transform);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(global::UnityEngine.Transform value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.ShootPoint() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackEvent() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveEvent value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.StartAttackRequest() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.ContactTakeDamage.BodyContactDamage() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth CurrentHealthC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.CurrentHealth() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessCurrentTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DeathProcessInitialTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath>();

		public global::System.Collections.Generic.List<global::UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out global::System.Collections.Generic.List<global::UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath component);
			if (result)
				value = component.Value;
			else
				value = default(global::System.Collections.Generic.List<global::UnityEngine.Collider>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath() { Value = new global::System.Collections.Generic.List<global::UnityEngine.Collider>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(global::System.Collections.Generic.List<global::UnityEngine.Collider> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.DisableCollidersOnDeath() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.HealthBarPoint HealthBarPointC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.HealthBarPoint>();

		public global::UnityEngine.Transform HealthBarPoint => HealthBarPointC.Value;

		public bool TryGetHealthBarPoint(out global::UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.HealthBarPoint component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.Transform);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddHealthBarPoint(global::UnityEngine.Transform value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.HealthBarPoint() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess InDeadProcessC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> InDeadProcess => InDeadProcessC.Value;

		public bool TryGetInDeadProcess(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeadProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.InDeadProcess() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead IsDeadC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.IsDead() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth MaxHealthC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MaxHealth() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie MustDieC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustDie() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease MustSelfReleaseC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LafiCycle.MustSelfRelease() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Experience ExperienceC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Experience>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> Experience => ExperienceC.Value;

		public bool TryGetExperience(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Experience component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExperience()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Experience() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExperience(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Experience() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Level LevelC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Level>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int> Level => LevelC.Value;

		public bool TryGetLevel(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Level component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddLevel()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Level() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddLevel(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature.Level() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.Coins CoinsC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.Coins>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int> Coins => CoinsC.Value;

		public bool TryGetCoins(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.Coins component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCoins()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.Coins() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCoins(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<int> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.Coins() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsCollected IsCollectedC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsCollected>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> IsCollected => IsCollectedC.Value;

		public bool TryGetIsCollected(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsCollected component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsCollected()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsCollected() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsCollected(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsCollected() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullable IsPullableC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullable>();

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsPullable()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullable());
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullingProcess IsPullingProcessC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullingProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> IsPullingProcess => IsPullingProcessC.Value;

		public bool TryGetIsPullingProcess(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullingProcess component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsPullingProcess()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullingProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsPullingProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature.IsPullingProcess() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero.IsMainHero IsMainHeroC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero.IsMainHero>();

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero.IsMainHero());
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove CanMoveC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanMove() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate CanRotateC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(global::Assets._Progect.Develop.Runtime.Utillitles.Conditions.ICompositCondition value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.CanRotate() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving IsMovingC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.IsMoving() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveDirection() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.MoveSpeed() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::UnityEngine.Vector3> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationDirection() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MovementFeature.RotationSpeed() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider BodyColliderC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider>();

		public global::UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out global::UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.CapsuleCollider);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(global::UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.BodyCollider() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer ContactColliderBufferC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> ContactColliderBuffer => ContactColliderBufferC.Value;

		public bool TryGetContactColliderBuffer(out global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactColliderBuffer(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::UnityEngine.Collider> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactColliderBuffer() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(global::Assets._Progect.Develop.Runtime.Utillitles.Buffer<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactEntitiesBuffer() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask>();

		public global::UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out global::UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.LayerMask);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(global::UnityEngine.LayerMask value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.ContactsDetectingMask() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask DeathMaskC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask>();

		public global::UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out global::UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask component);
			if (result)
				value = component.Value;
			else
				value = default(global::UnityEngine.LayerMask);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(global::UnityEngine.LayerMask value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.DeathMask() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchAnotherTeam() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Sensors.IsTouchDeathMask() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.InSpawnProcess InSpawnProcessC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.InSpawnProcess>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> InSpawnProcess => InSpawnProcessC.Value;

		public bool TryGetInSpawnProcess(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.InSpawnProcess component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInSpawnProcess()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.InSpawnProcess() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInSpawnProcess(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<bool> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.InSpawnProcess() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnCurrentTime SpawnCurrentTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnCurrentTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> SpawnCurrentTime => SpawnCurrentTimeC.Value;

		public bool TryGetSpawnCurrentTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnCurrentTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnCurrentTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnCurrentTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnCurrentTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnInitialTime SpawnInitialTimeC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnInitialTime>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> SpawnInitialTime => SpawnInitialTimeC.Value;

		public bool TryGetSpawnInitialTime(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnInitialTime()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnInitialTime() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnInitialTime(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature.SpawnInitialTime() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.BaseStats BaseStatsC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.BaseStats>();

		public global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float> BaseStats => BaseStatsC.Value;

		public bool TryGetBaseStats(out global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.BaseStats component);
			if (result)
				value = component.Value;
			else
				value = default(global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBaseStats()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.BaseStats() { Value = new global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBaseStats(global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.BaseStats() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.ModifiedStats ModifiedStatsC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.ModifiedStats>();

		public global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float> ModifiedStats => ModifiedStatsC.Value;

		public bool TryGetModifiedStats(out global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.ModifiedStats component);
			if (result)
				value = component.Value;
			else
				value = default(global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddModifiedStats()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.ModifiedStats() { Value = new global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddModifiedStats(global::System.Collections.Generic.Dictionary<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatTypes, float> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.ModifiedStats() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.StatsEffects StatsEffectsC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.StatsEffects>();

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsEffectsList StatsEffects => StatsEffectsC.Value;

		public bool TryGetStatsEffects(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsEffectsList value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.StatsEffects component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsEffectsList);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStatsEffects()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.StatsEffects() { Value = new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsEffectsList() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStatsEffects(global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsEffectsList value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature.StatsFeatureComponents.StatsEffects() { Value = value });
		}

		public global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team TeamC => GetComponent<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team>();

		public global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams> value)
		{
			bool result = TryGetComponent(out global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team component);
			if (result)
				value = component.Value;
			else
				value = default(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams>);
			return result;
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team() { Value = new global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams>() });
		}

		public Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(global::Assets._Progect.Develop.Runtime.Utillitles.Reactivre.ReactiveVeriable<global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Teams> value)
		{
			return AddComponent(new global::Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory.Team() { Value = value });
		}

	}
}
