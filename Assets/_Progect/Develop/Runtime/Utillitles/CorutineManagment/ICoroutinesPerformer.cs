using System.Collections;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment
{
    public interface ICoroutinesPerformer
    {
        public Coroutine StartPerform(IEnumerator coroutineFunction);
        public void StopPerform(Coroutine coroutine);
    }
}