using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private ICoroutinesPerformer _coroutinesPerformer;
    private ResourcesAssetsLoader _resourcesAssetsLoader;

    private void Awake()
    {
        _resourcesAssetsLoader = CreateResoursesAssetLoader();
       
        _coroutinesPerformer = CreateCoroutinePerformer();
    }

    private ResourcesAssetsLoader CreateResoursesAssetLoader() => new ResourcesAssetsLoader();

    private CoroutinesPerformer CreateCoroutinePerformer()
    {
        CoroutinesPerformer coroutinesPerformerPrefab = _resourcesAssetsLoader.
           Load<CoroutinesPerformer>("Utillities/CoroutinesPerformer");

        return Instantiate(coroutinesPerformerPrefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _coroutinesPerformer.StartPerform(TestCoroutine());
        }
    }

    private IEnumerator TestCoroutine()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(1f);
        Debug.Log("End");

    }
}
