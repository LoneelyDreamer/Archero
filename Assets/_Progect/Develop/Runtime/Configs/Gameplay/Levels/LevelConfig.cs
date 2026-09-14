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
        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;
        public MineConfig InstallMine => _installMine;
        public MineConfig ExplodeMine => _explodeMine;
    }

}
