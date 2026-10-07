using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.Stats
{
    [CreateAssetMenu(menuName = "Configs/Meta/StatsViewConfig", fileName = "StatsViewConfig")]
    public class StatsViewConfig : ScriptableObject
    {
        [SerializeField] private List<StatViewConfig> _statsShowData;

        public StatViewConfig GetStatViewData(StatTypes statType) 
            => _statsShowData.First(s => s.Type == statType);

        [Serializable]
        public class StatViewConfig
        {
            [field: SerializeField] public StatTypes Type { get; private set; }
            [field: SerializeField] public string Name { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
        }
    }
}
