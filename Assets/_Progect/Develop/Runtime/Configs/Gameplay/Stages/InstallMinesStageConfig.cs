using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Stages
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Stages/NewInstallMinesStage", fileName = " InstallMinesStage")]
    public class InstallMinesStageConfig : StageConfig
    {
        [SerializeField] private MineConfig _constMine;
        [SerializeField] private MineConfig _instantMine;

        public MineConfig Const => _constMine;
        public MineConfig InstantMine => _instantMine;
    }
}
