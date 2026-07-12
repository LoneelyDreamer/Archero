using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Progect.Develop.Runtime.Utillitles.SceneManagment
{
    public class SceneLoaderServise
    {
        public IEnumerator LoadAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            AsyncOperation wait = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            yield return new WaitWhile(() => wait.isDone == false);
        }

        public IEnumerator UnloadAsync(string sceneName)
        {
            AsyncOperation wait = SceneManager.UnloadSceneAsync(sceneName);

            yield return new WaitWhile(() => wait.isDone == false);
        }
    }
}
