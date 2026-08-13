using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Teleport
{
    public class TeleportRadius : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

  

    public class TeleportSkillPrice : IEntityComponent
    {
        public ReactiveVeriable<float> Value;
    }

    public class CanUseTeleportSkill : IEntityComponent
    {
        public ICompositCondition Value;
    }

    public class StartTeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class StartTeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

}
