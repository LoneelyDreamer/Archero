using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment
{
    public class CoroutinesPerformer : MonoBehaviour, ICoroutinesPerformer
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public Coroutine StartPerform(IEnumerator coroutineFunction)
            => StartCoroutine(coroutineFunction);

        public void StopPerform(Coroutine coroutine)
          => StopCoroutine(coroutine);

    }
}