using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.Stages
{
    public class StagePresenter : IPresentor
    {
        private readonly IconTextView _view;
        private readonly StageProviderService _stageProviderService;

        private IDisposable _currentStageNumberDisposable;

        public StagePresenter(
            IconTextView iconTextView,
            StageProviderService stageProviderService)
        {
            _view = iconTextView;
            _stageProviderService = stageProviderService;
        }

        public void Initialise()
        {
            _currentStageNumberDisposable = _stageProviderService.CurrentStageNumber.Subscribe(OnNextStageIndexChanged);

            UpdateStageNumber();
        }

        public void Dispose()
        {
            _currentStageNumberDisposable.Dispose();
        }

        private void OnNextStageIndexChanged(int arg1, int arg2) => UpdateStageNumber();

        private void UpdateStageNumber()
        {
            _view.SetText($"{_stageProviderService.CurrentStageNumber.Value} / {_stageProviderService.StagesCount}");
        }       
    }
}
