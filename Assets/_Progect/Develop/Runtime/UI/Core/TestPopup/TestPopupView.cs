using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Core.TestPopup
{
    public class TestPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text) => _text.text = text;

        protected override void ModifyShowAnimations(Sequence animation)
        {
            base.ModifyShowAnimations(animation);

            animation
                .Append(_text
                    .DOFade(1, 0.2f)
                    .From(0));
        }
    }
}
