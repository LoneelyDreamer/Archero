using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewSimpleEnemyConfig", fileName = "SimpleEnemyConfig")]
    public class SimpleEnemyConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/SimpleEnemy";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 3;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float AOEDamage { get; private set; } = 25;
        [field: SerializeField, Min(0)] public float AOERadius { get; private set; } = 4;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0.2f;
        [field: SerializeField, Min(0)] public float SelfDetonationTime { get; private set; } = 0.5f;
    }
}
