using System.Collections;
using UnityEngine;

public interface ICoroutinesPerformer 
{
    public Coroutine StartPerform(IEnumerator coroutineFunction);
    public void StopPerform(Coroutine coroutine);
}
