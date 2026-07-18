using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/NewStartWalletConfig", fileName = "StartWalletConfig")]
    public class StartWalletConfig : ScriptableObject
    {
        [SerializeField] private List<CurrencyConfig> _values;

        public int GetValuesFor(CurrenceTypes currenceType)
            => _values.First(config => config.Type == currenceType).Value;

        [Serializable]
        private class CurrencyConfig
        {
            [field: SerializeField] public CurrenceTypes Type {  get; private set; }   
            [field: SerializeField] public int Value {  get; private set; }   
        }

    }
}
