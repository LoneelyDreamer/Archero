using Assets._Progect.Develop.Runtime.UI.Core;
using DG.Tweening;
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
    public class AbilitySelectPopupView : PopupViewBase
    {
        public event Action SelectButtonClicked;

        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _selectAbilityText;

        [SerializeField] private Button _selectButton;

        [SerializeField] private SelectableAbilityListView _abilityListView;

        public SelectableAbilityListView AbilityListView => _abilityListView;

        private void OnEnable()
        {
            _selectButton.onClick.AddListener(OnSelecedButtonClicked);
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(OnSelecedButtonClicked);
        }

        public void SetTitle(string text) => _title.text = text;

        public void SelectButtonOn() => _selectButton.gameObject.SetActive(true);

        public void SelectButtonOff() => _selectButton.gameObject.SetActive(false);

        public void SetAdditionalText(string additionalText) => _selectAbilityText.text = additionalText;

        protected override void ModifyShowAnimations(Sequence animation)
        {
            base.ModifyShowAnimations(animation);

            animation.Append(_abilityListView.Show());
        }

        protected override void ModifyHideAnimations(Sequence animation)
        {
            base.ModifyHideAnimations(animation);

            animation.Append(_abilityListView.Hide());
        }

        private void OnSelecedButtonClicked() => SelectButtonClicked?.Invoke();
    }
}
