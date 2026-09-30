using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class AbilitiesList
    {
        public event Action<Ability> Added;

        private List<Ability> _elements;

        private IReadOnlyList<Ability> Elements => _elements;

        public virtual void Add(Ability element)
        {
            _elements.Add(element);
            Added?.Invoke(element);
        }
    }
}
    