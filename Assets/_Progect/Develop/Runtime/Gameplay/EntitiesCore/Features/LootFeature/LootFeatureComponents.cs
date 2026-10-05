using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class IsPullable : IEntityComponent
    {

    }

    public class IsPullingProcess : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }

    public class IsCollected : IEntityComponent
    {
        public ReactiveVeriable<bool> Value;
    }

}
