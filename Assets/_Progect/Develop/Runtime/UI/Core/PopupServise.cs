using Assets._Progect.Develop.Runtime.UI.Core.TestPopup;
using Assets._Progect.Develop.Runtime.UI.CupchPopup;
using Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Core
{
    public abstract class PopupServise : IDisposable
    {
        protected readonly ViewsFactory ViewsFactory;
        private readonly ProjectPresentorFactory _presentorsFactory;
        private readonly Dictionary<PopupPresentorBase, PopupInfo> _presenterToInfo = new();

        protected PopupServise(ViewsFactory viewsFactory, ProjectPresentorFactory presentorsFactory)
        {
            ViewsFactory = viewsFactory;
           _presentorsFactory = presentorsFactory;
        }

        protected abstract Transform PopuoLayer {  get; }

        public TestPopupPresentor OpenTestPopup(Action closedCallback = null)
        {
            TestPopupView view = ViewsFactory.Create<TestPopupView>(ViewIDs.TestPopup, PopuoLayer);

            TestPopupPresentor popup = _presentorsFactory.CreateTestPopupPresentor(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }

        //public CupchaPopupPresentor OpenCupchaPopup()
        //{
        //    CupchaPopupPresentor popup = _presentorsFactory.CreateCu
        //}

        public LevelsMenuPopupPresentor OpenLevelsMenuPopup()
        {
            LevelsMenuPopupView view = ViewsFactory.Create<LevelsMenuPopupView>(ViewIDs.LevelsMenuPopup, PopuoLayer);

            LevelsMenuPopupPresentor popup = _presentorsFactory.CreateLevelsMenuPopupPresentor(view);

            OnPopupCreated(popup, view);

            return popup;
        }

        public void ClosePopup(PopupPresentorBase popup)
        {
            popup.CloseRequest -= ClosePopup;

            popup.Hide(() =>
            {
                _presenterToInfo[popup].CloseCallBack?.Invoke();

                DisposeFor(popup);
                _presenterToInfo.Remove(popup);
            });
        }

        public void Dispose()
        {
            foreach (PopupPresentorBase popup in _presenterToInfo.Keys)
            {
                popup.CloseRequest -= ClosePopup;
                DisposeFor(popup);
            }

            _presenterToInfo.Clear();
        }

        protected void OnPopupCreated(
            PopupPresentorBase popup,
            PopupViewBase view,
            Action closedCallBack = null)
        {
            PopupInfo popupInfo = new PopupInfo(view, closedCallBack);

            _presenterToInfo.Add(popup, popupInfo);
            popup.Initialise();
            popup.Show();

            popup.CloseRequest += ClosePopup;
        }

        private void DisposeFor(PopupPresentorBase popup)
        {
            popup.Dispose();
            ViewsFactory.Release(_presenterToInfo[popup].View);
        }


        private class PopupInfo
        {
            public PopupInfo(PopupViewBase view, Action closeCallBack)
            {
                View = view;
                CloseCallBack = closeCallBack;
            }

            public PopupViewBase View { get; }
            public Action CloseCallBack { get; }
        }

    }
}
