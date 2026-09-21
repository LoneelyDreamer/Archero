using System;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AI
{
    public interface IBrain : IDisposable
    {
        void Enable();

        void Disable();

        void Update(float deltaTime);
    }
}
