using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;

namespace Assets._Progect.Develop.Runtime.UI.Core.TestPopup
{
    public class TestPopupPresentor : PopupPresentorBase
    {
        private readonly TestPopupView _view;

        public TestPopupPresentor(TestPopupView view, ICoroutinesPerformer coroutinesPerformer) : base(coroutinesPerformer)
        {
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetText("TEST TITLE");
        }
    }
}
