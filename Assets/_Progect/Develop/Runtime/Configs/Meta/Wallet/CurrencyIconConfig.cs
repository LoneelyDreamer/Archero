using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/NewCurrencyIconConfig", fileName = "CurrencyIconConfig")]
    public class CurrencyIconConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyConfig> _configs;

        public Sprite GetSpriteFor(CurrenceTypes currenceType)
            => _configs.First(config => config.Type == currenceType).Sprite;

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrenceTypes Type { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
        }

    }
}
