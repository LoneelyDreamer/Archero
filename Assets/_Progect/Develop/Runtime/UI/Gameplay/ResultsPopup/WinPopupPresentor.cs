using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.ResultsPopup
{
    public class WinPopupPresentor : PopupPresentorBase
    {
        private const string TitleName = "YOU WIN!!!";

        private readonly WinPopupView _view;
        private readonly SceneSwitherService _sceneSwitherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public WinPopupPresentor(
            WinPopupView view, 
            SceneSwitherService sceneSwitherService,
            ICoroutinesPerformer coroutinesPerformer) : base(coroutinesPerformer)
        {
            _view = view;
            _sceneSwitherService = sceneSwitherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetTitle(TitleName);
            _view.ContinueClicked += OnContinueClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.ContinueClicked -= OnContinueClicked;
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ContinueClicked -= OnContinueClicked;
        }

        private void OnContinueClicked()
        {
            _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));    

            OnCloseRequest();
        }
    }
}
