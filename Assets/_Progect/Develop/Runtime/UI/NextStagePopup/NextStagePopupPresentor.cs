using Assets._Progect.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.NextStagePopup
{
    public class NextStagePopupPresentor : PopupPresentorBase
    {
        public event Action Confirmed;

        private const string _text = "NextStage";

        private readonly ClickService _clickService;
        private readonly NextStagePopupView _view;

        public NextStagePopupPresentor(
            ICoroutinesPerformer coroutinesPerformer,        
            ClickService clickService,
            NextStagePopupView view) : base(coroutinesPerformer)
        {
            _clickService = clickService;
            _view = view;
        }
        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();
            _view.SetText(_text);           
        }

        public override void Dispose()
        {
            base.Dispose();
            _view.OnNextStageButtonClicked -= OnViewClicked;
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();
            _view.OnNextStageButtonClicked += OnViewClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();
            _view.OnNextStageButtonClicked -= OnViewClicked;
        }

        private void OnViewClicked() => Confirmed?.Invoke();

    }
}
