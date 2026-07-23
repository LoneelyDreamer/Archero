using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;

namespace Assets._Progect.Develop.Runtime.UI.Wallet
{
    public class CurrencyPresentor : IPresentor
    {
        private readonly IReadOnlyVeriable<int> _currency;
        private readonly CurrenceTypes _currenceTypes;
        private readonly CurrencyIconConfig _currencyIconConfig;

        private readonly IconTextView _view;

        private IDisposable _disposable;
        public CurrencyPresentor(
            IReadOnlyVeriable<int> currency,
            CurrenceTypes currenceTypes,
            CurrencyIconConfig currencyIconConfig,
            IconTextView view)
        {
            _currency = currency;
            _currenceTypes = currenceTypes;
            _currencyIconConfig = currencyIconConfig;
            _view = view;
        }

        public IconTextView View => _view;

        public void Initialise()
        {
            UpdateValue(_currency.Value);
            _view.SetIcon(_currencyIconConfig.GetSpriteFor(_currenceTypes));

            _disposable = _currency.Subscribe(OnCurrencyChanged);
        }


        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnCurrencyChanged(int arg1, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetText(value.ToString());


    }
}
