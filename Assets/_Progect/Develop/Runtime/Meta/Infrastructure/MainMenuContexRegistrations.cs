using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContexRegistrations
    {
        public static void Process(DIContainer container)
        {
            Debug.Log("Процесс регистрации сервисов на сцене меню");
        }
    }
}
