using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Infrastructure
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void ProcessRegisration(DIContainer container, IInputSceneArgs sceneArgs = null);

        public abstract IEnumerator Initialize();

        public abstract void Run();
    }
}
