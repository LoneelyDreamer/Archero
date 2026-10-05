using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/ExperienceLootConfig", fileName = "ExperienceLootConfig")]
    public class ExperienceLootConfig : LootConfig
    {
        [field: SerializeField] public float Experience { get; private set; }
    }
}
