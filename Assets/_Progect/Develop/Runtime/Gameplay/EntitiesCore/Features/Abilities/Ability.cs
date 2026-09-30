using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public abstract class Ability
    {
        protected Ability(string iD)
        {
            ID = iD;
        }

        public string ID { get; }

        public abstract void Actvate();
    }
}
