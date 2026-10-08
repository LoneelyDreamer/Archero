using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using UnityEngine.SceneManagement;

namespace Assets._Progect.Develop.Runtime.UI.StatsUpgradePopup
{
    public class CharacterPreviewPresentor : IPresentor
    {
        private SceneLoaderServise _sceneLoaderServise;
        private ICoroutinesPerformer _coroutinesPerformer;

        public CharacterPreviewPresentor(
            SceneLoaderServise sceneLoaderServise,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _sceneLoaderServise = sceneLoaderServise;
            _coroutinesPerformer = coroutinesPerformer;
        }
      
        public void Initialise()
        {
            _coroutinesPerformer.StartPerform(_sceneLoaderServise.LoadAsync(Scenes.CharecterPreviewScene, LoadSceneMode.Additive));
        }

        public void Dispose()
        {
            _coroutinesPerformer.StartPerform(_sceneLoaderServise.UnloadAsync(Scenes.CharecterPreviewScene));
        }


    }
}
    