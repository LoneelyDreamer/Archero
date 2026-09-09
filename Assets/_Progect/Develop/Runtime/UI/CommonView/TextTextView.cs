using Assets._Progect.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.CommonView
{
    public class TextTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _valueText;

        public void SetTextTitl(string text) => _titleText.text = text;
        public void SetTextValue(string text) => _valueText.text = text;
    }
}
