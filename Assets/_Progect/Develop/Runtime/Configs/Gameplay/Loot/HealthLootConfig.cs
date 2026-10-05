using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/HealthLootConfig", fileName = "HealthLootConfig")]

    public class HealthLootConfig : LootConfig
    {
        [field: SerializeField] public float Health { get; private set; }
    }
}
