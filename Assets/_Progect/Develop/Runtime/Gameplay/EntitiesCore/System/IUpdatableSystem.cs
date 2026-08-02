namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System
{
    public interface IUpdatableSystem : IEntitySystem
    {
        void OnUpdate(float deltaTime);
    }


}
