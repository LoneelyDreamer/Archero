using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Wallet
{
    public class WalletPresentor : IPresentor
    {
        private readonly WalletServise _walletServise;
        private readonly ProjectPresentorFactory _presentorFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _view;

        private readonly List<CurrencyPresentor> _currencyPresentors = new();

        public WalletPresentor(WalletServise walletServise,
            ProjectPresentorFactory projectPresentorFactory,
            ViewsFactory viewsFactory,
            IconTextListView view)
        {
            _walletServise = walletServise;
            _presentorFactory = projectPresentorFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialise()
        {
            foreach(CurrenceTypes currenceTypes in _walletServise.AvalableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewIDs.CurrencyView);

                _view.Add(currencyView);

                CurrencyPresentor currencyPresentor = _presentorFactory.CreateCurrencyPresentor(
                   currencyView,
                   _walletServise.GetCurrence(currenceTypes),
                   currenceTypes);

                currencyPresentor.Initialise();

                Debug.Log("Initialise");
                _currencyPresentors.Add(currencyPresentor);
            }
        }

        public void Dispose() 
        {
            foreach(CurrencyPresentor currencyPresentor in _currencyPresentors)
            {
                _view.Remove(currencyPresentor.View);
                _viewsFactory.Release(currencyPresentor.View);
                currencyPresentor.Dispose();
            }

            _currencyPresentors.Clear();
        }
    }

   
}
