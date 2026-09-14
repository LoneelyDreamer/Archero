using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.NextStagePopup
{
    public class NextStagePopupView : PopupViewBase
    {
        public event Action OnNextStageButtonClicked;

        [SerializeField] private TMP_Text _nextStageText;
        [SerializeField] private Button _nextStageButton;

        private void OnEnable() => _nextStageButton.onClick.AddListener(OnNextStageClicked);

        private void OnDisable() => _nextStageButton.onClick.RemoveListener(OnNextStageClicked);

        private void OnNextStageClicked()
        {
            OnNextStageButtonClicked?.Invoke();
        }

        public void SetText(string text) => _nextStageText.text = text;


    }
}
