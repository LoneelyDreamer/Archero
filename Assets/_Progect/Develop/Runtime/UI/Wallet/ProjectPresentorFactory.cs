using Assets._Progect.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Core.TestPopup;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;

namespace Assets._Progect.Develop.Runtime.UI.Wallet
{
    public class ProjectPresentorFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentorFactory(DIContainer container)
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

        public WalletPresentor CreateWalletPresentor(IconTextListView view)
        {
            return new WalletPresentor(
                _container.Resolve<WalletServise>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);
        }

        public TestPopupPresentor CreateTestPopupPresentor(TestPopupView view)
        {
            return new TestPopupPresentor(view,
                _container.Resolve<ICoroutinesPerformer>());
        }
    }
}
