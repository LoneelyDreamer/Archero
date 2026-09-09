using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OpenLevelsMenuButtonClicked;
        public event Action ResetRateButtoClicked;
        [field: SerializeField] public IconTextListView WalletView {  get; private set; }
        [field: SerializeField] public TextTextListView RateView {  get; private set; }

        [SerializeField] private Button _openLevelsMenuButton;
        [SerializeField] private Button _resetRateButton;

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
            _resetRateButton.onClick.AddListener(OnResetRateButtoClickedClicked);
        }

        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
            _resetRateButton.onClick.RemoveListener(OnResetRateButtoClickedClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();   
        private void OnResetRateButtoClickedClicked() => ResetRateButtoClicked?.Invoke();   
    }
}
