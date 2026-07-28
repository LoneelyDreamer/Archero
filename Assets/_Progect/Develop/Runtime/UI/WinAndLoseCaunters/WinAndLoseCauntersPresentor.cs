using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.WinAndLoseCaunters
{
    public class WinAndLoseCauntersPresentor : IPresentor
    {
        private readonly WinAndLoseCauntersServise _servise;
        private readonly ProjectPresentorFactory _presentorFactory;
        private readonly ViewsFactory _viewsFactory;
        private readonly TextTextListView _view;

        private readonly List<RatePresentor> _ratePresentors = new();

        public WinAndLoseCauntersPresentor(WinAndLoseCauntersServise servise, 
            ProjectPresentorFactory presentorFactory,
            ViewsFactory viewsFactory,
            TextTextListView view)
        {
            _servise = servise;
            _presentorFactory = presentorFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialise()
        {
            foreach (CauntersTypes cauntersType in _servise.AvalableCaunters)
            {
                TextTextView currencyView = _viewsFactory.Create<TextTextView>(ViewIDs.CaunterView);

                _view.Add(currencyView);

                RatePresentor ratePresentor = _presentorFactory.CreateWinAndLoseRatePresentor(
                    _servise.GetCaunter(cauntersType),
                    cauntersType,
                    currencyView);


                ratePresentor.Initialise();

                Debug.Log("Initialise");
                _ratePresentors.Add(ratePresentor);
            }
        }


        public void Dispose()
        {
            foreach (RatePresentor ratePresentor in _ratePresentors)
            {
                _view.Remove(ratePresentor.View);
                _viewsFactory.Release(ratePresentor.View);
                ratePresentor.Dispose();
            }

            _ratePresentors.Clear();
        }
       
    }
}
