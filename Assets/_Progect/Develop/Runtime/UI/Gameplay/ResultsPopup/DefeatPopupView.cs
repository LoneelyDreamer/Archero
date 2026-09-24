using Assets._Progect.Develop.Runtime.UI.Core;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.ResultsPopup
{
    public class DefeatPopupView : PopupViewBase
    {
        public event Action ContinueClicked;
        public event Action RestartClicked;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        public void SetTitle(string text) => _text.text = text;

        protected override void OnPreShow()
        {
            base.OnPreShow();

            _continueButton.onClick.AddListener(OnContinueButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);       
        }    

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _continueButton.onClick.RemoveListener(OnContinueButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }


        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(OnContinueButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        public void OnRestartButtonClicked() => RestartClicked?.Invoke();       

        public void OnContinueButtonClicked() => ContinueClicked?.Invoke();

    }
}
