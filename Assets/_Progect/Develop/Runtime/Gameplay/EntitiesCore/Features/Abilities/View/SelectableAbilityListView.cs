using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.View
{
    public class SelectableAbilityListView : ElementsListView<SelectableAbilityView>, IShowableView
    {
        private Sequence _currentAnimation;

        public void Select(SelectableAbilityView selectableAbilityView)
        {
            foreach (SelectableAbilityView view in Elements)
            {
                view.Unselect();

                selectableAbilityView.Select();
            }
        }

        public Tween Hide()
        {
            _currentAnimation?.Kill();
            _currentAnimation = DOTween.Sequence();

            foreach (SelectableAbilityView view in Elements)
            {
                _currentAnimation.Append(view.Hide());
                _currentAnimation.AppendInterval(0.2f);
            }

            return _currentAnimation.SetUpdate(true).Play();
        }

        public Tween Show()
        {
            _currentAnimation?.Kill();
            _currentAnimation = DOTween.Sequence();

            foreach (SelectableAbilityView view in Elements)
            {
                _currentAnimation.Append(view.Show());
                _currentAnimation.AppendInterval(0.2f);
            }

            return _currentAnimation.SetUpdate(true).Play();
        }
    }
}
