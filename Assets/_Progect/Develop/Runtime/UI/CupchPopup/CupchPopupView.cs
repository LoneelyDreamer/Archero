using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.CupchPopup
{
    public class CupchPopupView : PopupViewBase
    {
        public event Action<string> TextEntered;

        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _cupchText;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _inputTextbutton;

        private string _currentText;

        public void SetTitle(string title) => _title.text = title;
        public void SetCupcha(string cupcha) => _cupchText.text = cupcha;

        private void OnEnable()
        {
            _inputTextbutton.onClick.AddListener(OnTextEntered);
            //_inputField.onEndEdit.AddListener(OnTextEntered);      
        }
        private void OnDisable()
        {
            _inputTextbutton.onClick.RemoveListener(OnTextEntered);
            //_inputField.onEndEdit.RemoveListener(OnTextEntered);
        }

        public void ResetText()
        {
            _inputField.text = string.Empty;
        }

        private void OnTextEntered()
        {
            _currentText = _inputField.text;
            TextEntered?.Invoke(_currentText);

            Debug.Log("Click");
            Debug.Log("_currentText =" + _currentText);

        }

    }
}
