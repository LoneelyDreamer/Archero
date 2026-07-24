using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Core.TestPopup
{
    public class TestPopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text) => _text.text = text;
    }
}
