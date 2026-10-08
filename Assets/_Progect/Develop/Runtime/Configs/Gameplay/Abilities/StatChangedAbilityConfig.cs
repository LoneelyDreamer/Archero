using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities
{
     [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/StatChangedAbilityConfig", fileName = "StatChangedAbilityConfig")]
    public class StatChangedAbilityConfig : AbilitiyConfig
    {
        [field: SerializeField] public StatTypes StatType { get; private set; }

        [SerializeField] private StatChangeOperation _operation;
        [SerializeField] private float _value;
        public override int MaxLevel => 1;

        public Func<float, float> GetApplyEffect()
        {
            switch (_operation)
            {
                case StatChangeOperation.Add:
                    return stat => stat += _value;

                case StatChangeOperation.Multiply:
                    return stat => stat *= _value;

                default:
                    throw new InvalidOperationException();
            }
        }

        private enum StatChangeOperation
        {
            Multiply,
            Add
        }
    }
}
