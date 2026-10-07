using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.StatsUpgradePopup
{
    public class BuyButtonView : MonoBehaviour, IView
    {
        public event Action Click;

        [SerializeField] private Image _backgraund;
        [SerializeField] private Button _button;

        [SerializeField] private Sprite _availableSprite;
        [SerializeField] private Sprite _lockedSprite;

        [Space,SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _priceIcon;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Click?.Invoke();
        }

        public virtual void Lock() => _backgraund.sprite = _lockedSprite;
        public virtual void Unlock() => _backgraund.sprite = _availableSprite;

        public void SetPriceText(string priceText) => _priceText.text = priceText; 

        public void SetIcon(Sprite icon) => _priceIcon.sprite = icon;

        public void HideIcon() => _priceIcon.gameObject.SetActive(false);
        public void ShowIcon() => _priceIcon.gameObject.SetActive(true);


    }
}
