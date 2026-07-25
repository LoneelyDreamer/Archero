using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _mainGroup;
        [SerializeField] private Image _anticlicker;
        [SerializeField] private Transform _body;

        private Tween _currentAnimation;

        private void Awake()
        {
            _mainGroup.alpha = 0;
        }

        public void OnCloseButtonClicked() => CloseRequest?.Invoke();

        public Tween Show()
        {
            KillCurrentAnimation();

            OnPreShow();

            _mainGroup.alpha = 1;

            Sequence animation = DOTween.Sequence();

            animation
                .Append(_anticlicker
                    .DOFade(0.75f, 0.2f)
                    .From(0))
                .Join(_body
                    .DOScale(1, 0.5f)
                    .From(0)
                    .SetEase(Ease.OutBack));

            ModifyShowAnimations(animation);

            animation.OnComplete(OnPostShow);

           return _currentAnimation = animation;
        }

        public Tween Hide()
        {
            KillCurrentAnimation();

            OnPreHide();

            Sequence animation = DOTween.Sequence();

            ModifyShowAnimations(animation);

            animation.OnComplete(OnPostHide);

            return _currentAnimation = animation;
            
        }

        protected virtual void ModifyShowAnimations(Sequence animation) { }
        protected virtual void ModifyHideAnimations(Sequence animation) { }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreShow() { }

        protected virtual void OnPostHide() { }

        protected virtual void OnPreHide() { }

        private void OnDestroy() => KillCurrentAnimation();

        private void KillCurrentAnimation()
        {
            if (_currentAnimation != null)
                _currentAnimation.Kill();
        }
    }
}
