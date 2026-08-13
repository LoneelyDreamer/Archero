using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Energy
{
    public class CurrentEnergy : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class MaxEnergy : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class EnergyRespawnTimeStep : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

}
