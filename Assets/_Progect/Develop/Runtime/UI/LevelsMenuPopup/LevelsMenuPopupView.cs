using Assets._Progect.Develop.Runtime.UI.Core;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.LevelsMenuPopup
{
    public class LevelsMenuPopupView : PopupViewBase  
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private LevelTileListView _levelTileListView;

        public LevelTileListView LevelTileListView => _levelTileListView;

        public void SetTitle(string title) => _title.text = title;

        protected override void ModifyShowAnimations(Sequence animation)
        {
            base.ModifyShowAnimations(animation);

            foreach(LevelTileView levelTileView in _levelTileListView.Elements)
            {
                animation.Append(levelTileView.Show());
                animation.AppendInterval(0.1f);
            }
        }
    }
}
