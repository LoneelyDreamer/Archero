namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System
{
    public interface IInitializableSystem : IEntitySystem
    {
        void OnInit(EntityLifeContext entity);
    }


}
