using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature
{
    public interface IStatsEffect
    {
        void ApplyTo(Dictionary<StatTypes, float> stats);
    }
}
