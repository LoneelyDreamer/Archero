using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/GoldLootConfig", fileName = "GoldLootConfig")]
    public class CoinLootConfig : LootConfig
    {
        [field: SerializeField] public int Coins { get; private set; }
    }
}
