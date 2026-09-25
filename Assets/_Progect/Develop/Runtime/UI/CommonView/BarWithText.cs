using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.CommonView
{
    public class BarWithText : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Bar _bar;

        public void UpdateText(string text) => _text.text = text;
        public void UpdateSlider(float sliderValue) => _bar.UpdateValue(sliderValue);
        public void SetFillerColor(Color color) => _bar.SetFillerColor(color);  


    }
}
