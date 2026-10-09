using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/BounceProgectileAbilityConfig", fileName = "BounceProgectileAbilityConfig")]
    public class BounceProgectileAbilityConfig : AbilitiyConfig
    {
        [SerializeField] private List<int> _bounceCountByLevel;

        [field: SerializeField] public LayerMask LayerBounceRection {  get; private set; }

        public override int MaxLevel => _bounceCountByLevel.Count;
        
        public int GetBounceCountBy(int level) => _bounceCountByLevel[level - 1];   
    }
}
