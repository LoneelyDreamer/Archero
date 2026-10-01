using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.View
{
    public class AbilityIcon : MonoBehaviour, IView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Transform _levelParant;
        [SerializeField] private TMP_Text _level;

        public void HideLevel() => _level.gameObject.SetActive(false);
        public void showLevel() => _levelParant.gameObject.SetActive(true);

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public void SetLevel(string level)
        {
            _level.text = level;
        }

    }
}
