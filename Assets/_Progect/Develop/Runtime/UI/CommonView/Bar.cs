using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.UI.CommonView
{
    public class Bar : MonoBehaviour, IView 
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _filler;

        public void UpdateValue(float sliderValue) =>_slider.value = sliderValue;

        public void SetFillerColor(Color color) => _filler.color = color;
    }
}
