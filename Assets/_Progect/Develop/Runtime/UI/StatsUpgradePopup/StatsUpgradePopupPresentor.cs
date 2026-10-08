using Assets._Progect.Develop.Runtime.Meta.Feathers.StatsUpgrade;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.StatsUpgradePopup
{
    public class StatsUpgradePopupPresentor : PopupPresentorBase
    {
        private readonly StatsUpgradablePopupView _view;
        private readonly ViewsFactory _viewFactory;
        private readonly ProjectPresentorFactory _projectPresentorFactory;
        private readonly StatsUpgradeService _statsUpgradeService;

        private List<UpgradableStatPresentor> _upgradableStatPresentors = new();
        private WalletPresentor _walletPresentor;
        private CharacterPreviewPresentor _characterPreviewPresentor;

        public StatsUpgradePopupPresentor(
            ICoroutinesPerformer coroutinesPerformer,
            StatsUpgradablePopupView view,
            ViewsFactory viewFactory,
            ProjectPresentorFactory projectPresentorFactory,
            StatsUpgradeService statsUpgradeService) : base(coroutinesPerformer)
        {
            _view = view;
            _viewFactory = viewFactory;
            _projectPresentorFactory = projectPresentorFactory;
            _statsUpgradeService = statsUpgradeService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetTitle("UPGRADE YOUR STATS");

            _walletPresentor = _projectPresentorFactory.CreateWalletPresentor(_view.CurrencyListView);
            _walletPresentor.Initialise();

            _characterPreviewPresentor = _projectPresentorFactory.CreateCharacterPreviewPresentor();
            _characterPreviewPresentor.Initialise();

            foreach (var statType in _statsUpgradeService.AvalableStats)
            {
                UpgradableStatView upgradableStatView = _viewFactory.Create<UpgradableStatView>(ViewIDs.UpgradableStatView);
                _view.UpgradableStatListView.Add(upgradableStatView);

                UpgradableStatPresentor upgradableStatPresentor = _projectPresentorFactory.CreateUpgradableStatPresentor(upgradableStatView, statType);
                _upgradableStatPresentors.Add(upgradableStatPresentor);
                upgradableStatPresentor.Initialise();
            }
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (UpgradableStatPresentor presentor in _upgradableStatPresentors)
                presentor.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (UpgradableStatPresentor presentor in _upgradableStatPresentors)
            {
                presentor.Dispose();
                _view.UpgradableStatListView.Remove(presentor.View);
                _viewFactory.Release(presentor.View);
            }

            _upgradableStatPresentors.Clear();

            _walletPresentor.Dispose();

            _characterPreviewPresentor.Dispose();
        }
    }
}
