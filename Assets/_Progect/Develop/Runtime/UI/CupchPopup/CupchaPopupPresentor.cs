using Assets._Progect.Develop.Runtime.Gameplay.BonusAndPenalty;
using Assets._Progect.Develop.Runtime.Gameplay.Cupcha;
using Assets._Progect.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.CupchPopup
{
    public class CupchaPopupPresentor : PopupPresentorBase, ISubscribePresentor
    {
        private const string TitleName = "Cupcha";

        private readonly CupchaServisce _cupchaServisce;
        private readonly SceneSwitherService _sceneSwitherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly ConfigsProviderServise _configsProviderServise;
        private readonly WinAndLoseCauntersServise _winAndLoseCauntersServise;
        private readonly BonusAndPenaltyServise _bonusAndPenaltyServise;
        private readonly PlayerDataProvider _playerDataProvider;

        private readonly int _mode;

        private readonly CupchPopupView _view;

        public CupchaPopupPresentor(
            CupchaServisce cupchaServisce,
            SceneSwitherService sceneSwitherService,
            ICoroutinesPerformer coroutinesPerformer,
            CupchPopupView view,
            BonusAndPenaltyServise bonusAndPenaltyServise,
            WinAndLoseCauntersServise winAndLoseCauntersServise,
            PlayerDataProvider playerDataProvider) : base(coroutinesPerformer)
        {
            _cupchaServisce = cupchaServisce;
            _sceneSwitherService = sceneSwitherService;
            _coroutinesPerformer = coroutinesPerformer;
            _view = view;
            _bonusAndPenaltyServise = bonusAndPenaltyServise;
            _winAndLoseCauntersServise = winAndLoseCauntersServise;
            _playerDataProvider = playerDataProvider;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetTitle(TitleName);

            string cupcha = _cupchaServisce.GanerateCupcha(_mode);

            _view.SetCupcha(cupcha);
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.TextEntered -= TextEntered;
        }

        public void Subscribe()
        {
            _view.TextEntered += TextEntered;
        }

        public void Unsubscribe()
        {
            _view.TextEntered -= TextEntered;
        }

        private void TextEntered(string inputText)
        {
            Debug.Log("Введено " + inputText);
            if (_cupchaServisce.CupchaCheak(inputText))
            {
                Debug.Log("Победа");
                _winAndLoseCauntersServise.Caunt(CauntersTypes.Wins);
                _bonusAndPenaltyServise.AddGoldBonus();

                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));

            }
            else
            {
                Debug.Log("Поражение");
                _winAndLoseCauntersServise.Caunt(CauntersTypes.Loses);

                _bonusAndPenaltyServise.AddGoldPenalty();

                _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
                _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.Gameplay, new GameplayInputArgs(1), new GameplayInputArgs(_mode)));
            }
        }
    }
}
