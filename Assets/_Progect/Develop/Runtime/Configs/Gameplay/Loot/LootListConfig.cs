using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/LootListConfig", fileName = "LootListConfig")]
    public class LootListConfig : ScriptableObject
    {
        [SerializeField] private List<LootConfig> _lootConfigs;

        public IReadOnlyList<LootConfig> LootConfigs => _lootConfigs;

        public LootConfig GetLootById(string id) => _lootConfigs.First(loot => loot.ID == id);
    }
}
