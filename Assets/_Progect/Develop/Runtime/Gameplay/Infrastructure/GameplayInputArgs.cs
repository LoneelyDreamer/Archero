namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(int levalNumber)
        {
            LevalNumber = levalNumber;
        }

        public int LevalNumber { get; }
    }

}
