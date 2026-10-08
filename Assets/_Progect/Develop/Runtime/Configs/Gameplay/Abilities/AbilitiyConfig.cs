using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities
{
    public abstract class AbilitiyConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        public abstract int MaxLevel { get; }

        //meta-data
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Discription { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        public bool IsUpgradable() => MaxLevel > 1;


    }
}
