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
        [SerializeField] private CanvasGroup _body;

        [SerializeField] private PopupAnimationTypes _animationType;

        private float _anticlickerDefaultAlfa;

        private Tween _currentAnimation;

        private void Awake()
        {
            _anticlickerDefaultAlfa = _anticlicker.color.a;
            _mainGroup.alpha = 0;
        }

        public void OnCloseButtonClicked() => CloseRequest?.Invoke();

        public Tween Show()
        {
            KillCurrentAnimation();

            OnPreShow();

            _mainGroup.alpha = 1;

            Sequence animation = PopupAnimationCreator
                .CreateShowAnimation(_body, _anticlicker, _animationType, _anticlickerDefaultAlfa);

            ModifyShowAnimations(animation);

            animation.OnComplete(OnPostShow);

           return _currentAnimation = animation.SetUpdate(true).Play();
        }

        public Tween Hide()
        {
            KillCurrentAnimation();

            OnPreHide();

            Sequence animation = PopupAnimationCreator
               .CreateHideAnimation(_body, _anticlicker, _animationType, _anticlickerDefaultAlfa);

            ModifyHideAnimations(animation);

            animation.OnComplete(OnPostHide);

            return _currentAnimation = animation.SetUpdate(true).Play();

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
