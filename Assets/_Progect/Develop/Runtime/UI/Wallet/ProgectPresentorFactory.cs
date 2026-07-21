using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Wallet
{
    public class ProgectPresentorFactory
    {
        private readonly DIContainer _container;

        public ProgectPresentorFactory(DIContainer container)
        {
            _container = container;
        }

        public CurrencyPresentor CreateCurrencyPresentor(
            IconTextView view,
            IReadOnlyVeriable<int> currency,
            CurrenceTypes currenceTypes)
        {
            return new CurrencyPresentor(
                currency,
                currenceTypes,
                _container.Resolve<ConfigsProviderServise>().GetConfig<CurrencyIconConfig>(),
                view);
        }
    }
}
