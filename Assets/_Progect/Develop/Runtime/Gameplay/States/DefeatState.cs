using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {   
        private readonly GameplayPopupServise _popupServise;

        public DefeatState(
            IInputService inputService,
            GameplayPopupServise popupServise) : base(inputService)
        {
            _popupServise = popupServise;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Defeat");

            _popupServise.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
           
        }
    }
}
