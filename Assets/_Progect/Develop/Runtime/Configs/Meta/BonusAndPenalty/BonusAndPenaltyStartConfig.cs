using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.BonusAndPenalty
{
    [CreateAssetMenu(menuName = "Configs/Meta/BonusAndPenalty", fileName = "BonusAndPenalty")]
    public class BonusAndPenaltyStartConfig : ScriptableObject
    {
        [field: SerializeField] public int WinGoldBonus { get; private set; }
        [field: SerializeField] public int LoseGoldPenalty { get; private set; }
    }
}