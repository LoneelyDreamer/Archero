using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.StatsUpgradePopup
{
    public class StatsUpgradablePopupView : PopupViewBase
    {
        [SerializeField] private TMP_Text _title;

        [field: SerializeField] public IconTextListView CurrencyListView { get; private set; }
        [field: SerializeField] public UpgradableStatListView UpgradableStatListView { get; private set; }

        public void SetTitle(string title) => _title.text = title;

    }
}
