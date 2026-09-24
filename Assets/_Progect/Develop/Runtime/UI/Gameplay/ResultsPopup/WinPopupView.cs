using Assets._Progect.Develop.Runtime.UI.Core;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.ResultsPopup
{
    public class WinPopupView : PopupViewBase
    {
        public event Action ContinueClicked;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private List<Transform> _starts;

        public void SetTitle(string text) => _text.text = text;

        public void OnContinueClick() => ContinueClicked?.Invoke();

        protected override void ModifyShowAnimations(Sequence animation)
        {
            base.ModifyShowAnimations(animation);

            foreach (Transform star in _starts)
            {
                animation
                    .Append(star.DOScale(1, 0.3f).SetEase(Ease.OutBack).From(0))
                    .Join(star.DOLocalRotate(Vector3.forward * 360, 0.3f, RotateMode.LocalAxisAdd)
                        .SetEase(Ease.OutCubic)
                        .From(Vector3.zero));
                animation.AppendInterval(0.1f);
            }
        }
    }
}
