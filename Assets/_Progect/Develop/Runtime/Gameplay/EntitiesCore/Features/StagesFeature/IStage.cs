using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature
{
    public interface IStage : IDisposable
    {
        IReadOnlyEvent Completed { get; }

        void Start();

        void Update(float deltaTime);
        void Cleanup();
    }
}
