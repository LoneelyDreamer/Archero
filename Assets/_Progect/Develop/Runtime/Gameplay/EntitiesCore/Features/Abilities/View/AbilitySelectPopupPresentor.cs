using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.AbilitiesDropingFeature;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay;
using Assets._Progect.Develop.Runtime.Utillitles.CorutineManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.View
{
    public class AbilitySelectPopupPresentor : PopupPresentorBase
    {
        private const int AbilitiesCount = 3;

        private const string Title = "LEVEL {0} IN THIS ADVANCHER";
        private const string SelectAbilityText = "Select Ability";

        private readonly AbilitySelectPopupView _view;

        private readonly Entity _entity;
        private readonly AbilityDropingService _abilityDropper;
        private readonly GameplayPresentorFactory _presentorFactory;
        private readonly ViewsFactory _viewsFactory;

        private List<SelectableAbilityPresenter> _presenters = new();
        private SelectableAbilityPresenter _selectedPresenter;

        public AbilitySelectPopupPresentor
            (ICoroutinesPerformer coroutinesPerformer,
            AbilitySelectPopupView view,
            Entity entity,  
            AbilityDropingService abilityDropper, 
            GameplayPresentorFactory gameplayPresentorFactory, 
            ViewsFactory viewsFactory) : base(coroutinesPerformer)
        {
            _view = view;
            _entity = entity;
            _abilityDropper = abilityDropper;
            _presentorFactory = gameplayPresentorFactory;
            _viewsFactory = viewsFactory;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialise()
        {
            base.Initialise();

            _view.SetTitle(string.Format(Title, 2));
            _view.SetAdditionalText(SelectAbilityText);
            _view.SelectButtonOff();

            _view.SelectButtonClicked += OnSelectButtonClicked;

            List<AbilitiyConfig> dropOptions = _abilityDropper.Drop(AbilitiesCount, _entity);

            for (int i = 0; i < dropOptions.Count; i++)
            {
                SelectableAbilityView selectableAbilityView = _viewsFactory.Create<SelectableAbilityView>(ViewIDs.SelectAbilityPopup);
                _view.AbilityListView.Add(selectableAbilityView);

                SelectableAbilityPresenter presenter = _presentorFactory
                    .CreateSelectableAbilityPresentor(dropOptions[i], selectableAbilityView, _entity);

                presenter.Selected += OnPresenterSelected;
                presenter.Initialise();

                _presenters.Add(presenter);
            }
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.SelectButtonOff();
            _view.SelectButtonClicked -= OnSelectButtonClicked;

            foreach (SelectableAbilityPresenter abilityPresenter in _presenters)
            {
                abilityPresenter.Selected -= OnPresenterSelected;
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.SelectButtonClicked -= OnSelectButtonClicked;

            foreach (SelectableAbilityPresenter abilityPresenter in _presenters)
            {
                abilityPresenter.Selected -= OnPresenterSelected;
                _view.AbilityListView.Remove(abilityPresenter.View);
                _viewsFactory.Release(abilityPresenter.View);
                abilityPresenter.Dispose();
            }

            _presenters.Clear();
        }

        private void OnPresenterSelected(SelectableAbilityPresenter selected)
        {
            _view.SelectButtonOn();
            _view.AbilityListView.Select(selected.View);
            _selectedPresenter = selected;
        }

        private void OnSelectButtonClicked()
        {
            _selectedPresenter.Provide();
            OnCloseRequest();
        }
    }
}
