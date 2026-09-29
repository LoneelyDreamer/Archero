using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public class StatsEffectsList
    {
        public event Action<IStatsEffect> Added;
        public event Action<IStatsEffect> Removed;

        private List<IStatsEffect> _elements = new();

        public IReadOnlyList<IStatsEffect> Elements => _elements;

        public virtual void Add(IStatsEffect element)
        {
            _elements.Add(element);
            Added?.Invoke(element);
        }

        public virtual void Remove(IStatsEffect element)
        {
            _elements.Remove(element);
            Removed?.Invoke(element);
        }

    }
}
