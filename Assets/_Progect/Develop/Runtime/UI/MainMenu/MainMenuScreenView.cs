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
        public event Action OpenUpgradeStatsButtonClicked;
        [field: SerializeField] public IconTextListView WalletView {  get; private set; }

        [SerializeField] private Button _openLevelsMenuButton;
        [SerializeField] private Button _openUpgradeStatsButton;

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
            _openUpgradeStatsButton.onClick.AddListener(OnpenUpgradeStatsButtonClicked);
        }
        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
            _openUpgradeStatsButton.onClick.RemoveListener(OnpenUpgradeStatsButtonClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();
        private void OnpenUpgradeStatsButtonClicked() => OpenUpgradeStatsButtonClicked?.Invoke();


    }
}
