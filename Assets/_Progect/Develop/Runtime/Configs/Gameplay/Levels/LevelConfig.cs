using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Configs.Gameplay.Stages;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLavelConfig", fileName = "LavelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<StageConfig> _stageConfigs;
        [SerializeField] private MineConfig _installMine;   // Const
        [SerializeField] private MineConfig _explodeMine;   // Instant
      
        [field: SerializeField] public string PrefabPath { get; private set; } = "Bilding/Hero";
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0.5f;

        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;
        public MineConfig InstallMine => _installMine;
        public MineConfig ExplodeMine => _explodeMine;
    }

}
