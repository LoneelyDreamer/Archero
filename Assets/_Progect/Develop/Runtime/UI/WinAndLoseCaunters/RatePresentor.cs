using Assets._Progect.Develop.Runtime.Configs.Meta.Caunter;
using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.WinAndLoseCaunters
{
    public class RatePresentor : IPresentor
    {
        private readonly IReadOnlyVeriable<int> _rate;
        private readonly CauntersTypes _cauntersType;

        private readonly TextTextView _view;

        private IDisposable _disposable;

        public RatePresentor(
            IReadOnlyVeriable<int> rate,
            CauntersTypes cauntersType,
            TextTextView view)
        {
            _rate = rate;
            _cauntersType = cauntersType;
            _view = view;
        }

        public TextTextView View => _view;

        public void Initialise()
        {
            UpdateValue(_rate.Value);

            _view.SetTextTitl(_cauntersType.ToString());

            _disposable = _rate.Subscribe(OnCurrencyChanged);
        }


        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnCurrencyChanged(int arg1, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetTextValue(value.ToString());
    }
}
