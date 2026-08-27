using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI.States
{
    public interface ITargetSelector
    {
        EntityLifeContext SelectTargetFrom(IEnumerable<EntityLifeContext> targets);
    }
}
