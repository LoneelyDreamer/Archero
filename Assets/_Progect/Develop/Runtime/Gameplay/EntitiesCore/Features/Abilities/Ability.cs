using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public abstract class Ability
    {
        private ReactiveVeriable<int> _currentLevel;

        protected Ability(string iD, int currentLevel, int maxLevel)
        {
            ID = iD;
            _currentLevel = new ReactiveVeriable<int>(currentLevel);
            MaxLevel = maxLevel;
        }

        public string ID { get; }
        public int MaxLevel { get; }

        public IReadOnlyVeriable<int> CurrentLevel => _currentLevel;

        public void AddLevel(int level)
        {
            int temp = _currentLevel.Value + level;

            if(temp > MaxLevel)
                throw new ArgumentException(nameof(level));

            _currentLevel.Value = temp;
        }

        public abstract void Actvate();
    }
}
