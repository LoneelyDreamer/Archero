using Assets._Progect.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelsMenuPopupPresentor : PopupPresentorBase
    {
        private const string TitleName = "Levels";

        private readonly ConfigsProviderServise _configsProviderServise;
        private readonly ProjectPresentorFactory _presentorFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly LevelsMenuPopupView _view;

        private readonly List<LevelTilePresentor> _levelTilePresentors = new();
        public LevelsMenuPopupPresentor(
            ICoroutinesPerformer coroutinesPerformer,
            ViewsFactory viewsFactory,
            LevelsMenuPopupView view,
            ConfigsProviderServise configsProviderServise,
            ProjectPresentorFactory presentorFactory) : base(coroutinesPerformer)
        {
            _viewsFactory = viewsFactory;
            _view = view;
            _configsProviderServise = configsProviderServise;
            _presentorFactory = presentorFactory;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetTitle(TitleName);

            LevelsListConfig levelsListConfig = _configsProviderServise.GetConfig<LevelsListConfig>();

            for (int i = 0; i < levelsListConfig.Levels.Count; i++)
            {
                LevelTileView levelTileView = _viewsFactory.Create<LevelTileView>(ViewIDs.LevelTile);

                _view.LevelTileListView.Add(levelTileView);

                LevelTilePresentor levelTilePresentor = _presentorFactory.CreateLevelTilePresentor(levelTileView, i + 1);

                levelTilePresentor.Initialise();

                _levelTilePresentors.Add(levelTilePresentor);
            }
        }
            

        public override void Dispose()
        {
            base.Dispose();

            foreach(LevelTilePresentor levelTilePresentor in _levelTilePresentors)
            {
                _view.LevelTileListView.Remove(levelTilePresentor.View);
                _viewsFactory.Release(levelTilePresentor.View);
                levelTilePresentor.Dispose();
            }

            _levelTilePresentors.Clear();
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();

            foreach (LevelTilePresentor levelTilePresentor in _levelTilePresentors)
                levelTilePresentor.Subscribe();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (LevelTilePresentor levelTilePresentor in _levelTilePresentors)
                levelTilePresentor.Unsubscribe();

        }
    }
}
