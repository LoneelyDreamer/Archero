using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.SceneManagment;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly SceneSwitherService _sceneSwitherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly WinAndLoseCauntersServise _winAndLoseCauntersServise;
        private readonly PlayerDataProvider _playerDataProvider;

        public DefeatState(
            IInputService inputService,
            SceneSwitherService sceneSwitherService,
            ICoroutinesPerformer coroutinesPerformer,
            WinAndLoseCauntersServise winAndLoseCauntersServise,
            PlayerDataProvider playerDataProvider) : base(inputService)
        {
            _sceneSwitherService = sceneSwitherService;
            _coroutinesPerformer = coroutinesPerformer;
            _winAndLoseCauntersServise = winAndLoseCauntersServise;
            _playerDataProvider = playerDataProvider;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Defeat");
            _winAndLoseCauntersServise.Caunt(CauntersTypes.Loses);

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _coroutinesPerformer.StartPerform(_sceneSwitherService.ProssesSwitchTo(Scenes.MainMenu));
        }

        public void Update(float deltaTime)
        {
        }
    }
}
