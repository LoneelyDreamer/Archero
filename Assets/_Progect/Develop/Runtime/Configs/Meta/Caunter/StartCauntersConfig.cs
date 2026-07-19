using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.Caunter
{
    [CreateAssetMenu(menuName = "Configs/Meta/Caunters/NewStartCauntersConfig", fileName = "StartCauntersConfig")]
    public class StartCauntersConfig : ScriptableObject
    {
        [SerializeField] private List<CauntersConfig> _values;

        public int GetValuesFor(CauntersTypes cauntersTypes)
            => _values.First(config => config.Type == cauntersTypes).Value;

        [Serializable]
        private class CauntersConfig
        {
            [field: SerializeField] public CauntersTypes Type { get; private set; }
            [field: SerializeField] public int Value { get; private set; }
        }
    }
}
