using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LevelUpFeature
{

    public class Experience : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class Level : IEntityComponent
    {
        public ReactiveVeriable<int> Value;
    }

}
