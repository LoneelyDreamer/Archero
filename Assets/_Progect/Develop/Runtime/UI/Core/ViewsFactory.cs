using Assets._Progect.Develop.Runtime.Utillitles.AssetsManager;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Progect.Develop.Runtime.UI.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;

        private Dictionary<string, string> _viewIDToResourcesPath = new Dictionary<string, string>()
        {
            {ViewIDs.CurrencyView,"UI/Wallet/CurranceView" },
            {ViewIDs.MainMenuScreen,"UI/MainMenu/MainMenuScreenView" },
            {ViewIDs.TestPopup,"UI/TestPopup" },
            {ViewIDs.LevelTile,"UI/LevelsMenuPopup/LevelTile" },
            {ViewIDs.LevelsMenuPopup,"UI/LevelsMenuPopup/LevelsMenuPopup" }
        };
        public ViewsFactory(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
        }

        public TView Create<TView>(string viewID, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (_viewIDToResourcesPath.TryGetValue(viewID, out string resourcePath) == false)
                throw new ArgumentException($"You did not set resource path for {typeof(TView)}, searched Id: {viewID} ");

            GameObject prefab = _resourcesAssetsLoader.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefab, parent);
            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)} component on view instance");

            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
        {
            Object.Destroy(view.gameObject);
        }
    }
}
