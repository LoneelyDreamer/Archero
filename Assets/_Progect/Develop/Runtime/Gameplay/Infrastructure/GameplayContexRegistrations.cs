using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContexRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            Debug.Log("Процесс регистрации сервисов на сцене геймплея");
        }
    }
}
