using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.ResultsPopup
{
    public class DefeatPopupPresentor : PopupPresentorBase
    {
        private const string TitleName = "YOU LOSE!!!";

        private readonly DefeatPopupView _view;
        private readonly SceneSwitherService _sceneSwitherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly GameplayInputArgs _gameplayLevelArgs;

        public DefeatPopupPresentor(
            DefeatPopupView view,
            SceneSwitherService sceneSwitherService, 
            ICoroutinesPerformer coroutinesPerformer,
            GameplayInputArgs gameplayInputArgs) : base(coroutinesPerformer)
        {
            _view = view;
            _sceneSwitherService = sceneSwitherService;
            _coroutinesPerformer = coroutinesPerformer;
            _gameplayLevelArgs = gameplayInputArgs;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetTitle(TitleName);

            _view.ContinueClicked += OnContinueClicked;
            _view.RestartClicked += OnRestartClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.ContinueClicked -= OnContinueClicked;
            _view.RestartClicked -= OnRestartClicked;
        }        

        public override void Dispose()
        {
            base.Dispose();

            _view.ContinueClicked -= OnContinueClicked;
            _view.RestartClicked -= OnRestartClicked;
        }

        private void OnContinueClicked()
        {
            _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
            OnCloseRequest();
        }

        private void OnRestartClicked()
        {
            _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(_gameplayLevelArgs.LevalNumber)));
            OnCloseRequest();
        }
    }
}
