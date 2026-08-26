namespace Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore
{
    public interface IUpdatableState : IState
    {
        void Update(float deltaTime);
    }
}
