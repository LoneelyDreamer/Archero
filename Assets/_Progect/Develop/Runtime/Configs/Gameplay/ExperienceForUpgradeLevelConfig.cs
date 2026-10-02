using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/ExperienceForUpgradeLevelConfig", fileName = "ExperienceForUpgradeLevelConfig")]
    public class ExperienceForUpgradeLevelConfig : ScriptableObject
    {
        [SerializeField] private List<float> _expirienceForLevel;
        
        public int MaxLevel => _expirienceForLevel.Count;

        public float GetExpirienceFor(int level) => _expirienceForLevel[level - 1];
    }
}
