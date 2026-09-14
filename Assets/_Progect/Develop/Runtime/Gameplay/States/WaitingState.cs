using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.UI.NextStagePopup;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class WaitingState : State, IUpdatableState
    {
        private readonly GameplayPopupServise _popupServise;
        private readonly ClickService _clickService;
        private readonly ReactiveVeriable<bool> _isReady = new();

        private NextStagePopupPresentor _popup;

        public WaitingState(GameplayPopupServise popupServise, ClickService clickService)
        {
            _popupServise = popupServise;
            _clickService = clickService;
        }

        public IReadOnlyVeriable<bool> IsReady => _isReady;

        public override void Enter()
        {
            base.Enter();

            _isReady.Value = false;

            // Пока игрок сидит в подготовке — он ставит мины
            _clickService.SetMode(ClickMode.InstallMines);

            _popup = _popupServise.OpenNextStagePopupPresentor();
            _popup.Confirmed += OnConfirmed;
        }

        private void OnConfirmed() => _isReady.Value = true;

        public void Update(float deltaTime) { }

        public override void Exit()
        {
            base.Exit();

            if (_popup != null)
            {
                _popup.Confirmed -= OnConfirmed;
                _popupServise.ClosePopup(_popup);
                _popup = null;
            }
        }
    }
}
