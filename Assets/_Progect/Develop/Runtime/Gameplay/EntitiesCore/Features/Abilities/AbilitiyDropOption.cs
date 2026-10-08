using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class AbilitiyDropOption
    {
        public AbilitiyDropOption(AbilitiyConfig config, int level)
        {
            Config = config;
            Level = level;
        }

        public AbilitiyConfig Config { get; }

        public int Level { get; }
    }
}
