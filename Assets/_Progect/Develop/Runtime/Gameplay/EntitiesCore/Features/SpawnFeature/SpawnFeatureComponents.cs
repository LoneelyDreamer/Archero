using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.SpawnFeature
{
    public class SpawnInitialTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class SpawnCurrentTime : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }
    
    public class InSpawnProcess : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }
}
