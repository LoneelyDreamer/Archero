using Assets._Progect.Develop.Runtime.UI.Core;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelTileView :MonoBehaviour, IShowableView
    {
        public event Action Clicked;

        [SerializeField] private Image _backgraund;
        [SerializeField] private TMP_Text _levelNumberText;
        [SerializeField] private Button _button;

        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _completedColor;
        [SerializeField] private Color _blockedColor;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }
      
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void SetLevel(string level) => _levelNumberText.text = level;

        public void SetBlock() => _backgraund.color = _blockedColor;
        public void SetComplete() => _backgraund.color = _completedColor;
        public void SetActive() => _backgraund.color = _activeColor;

        public Tween Show()
        {
            transform.DOKill();

            return transform
                .DOScale(1, 0.1f)
                .From(0)
                .SetUpdate(true)
                .Play();
        }

        public Tween Hide()
        {
            transform.DOKill();

            return DOTween.Sequence();
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
        private void OnClick() => Clicked?.Invoke();

    }
}
