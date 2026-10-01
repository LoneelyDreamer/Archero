using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities.View
{
    public class SelectableAbilityPresenter : IPresentor
    {
        public event Action<SelectableAbilityPresenter> Selected;

        private AbilitiesFactory _abilitiesFactory;
        private Entity _entity;

        public SelectableAbilityPresenter(
            AbilitiesFactory abilitiesFactory,
            Entity entity,
            AbilitiyConfig abilitiyConfig,
            SelectableAbilityView view)
        {
            _abilitiesFactory = abilitiesFactory;
            _entity = entity;
            AbilitiyConfig = abilitiyConfig;
            View = view;
        }

        public AbilitiyConfig AbilitiyConfig { get; }
        public SelectableAbilityView View { get; }

        public void Initialise()
        {
            View.SetName(AbilitiyConfig.Name);
            View.SetDescription(AbilitiyConfig.Discription);
            View.Icon.SetIcon(AbilitiyConfig.Icon);

            View.Icon.HideLevel();
            View.SetTableText("NEW");

            View.Clicked += OnViewClicked;
        }
        public void Dispose()
        {
            View.Clicked -= OnViewClicked;
        }

        public void Provide()
        {
            Ability ability = _abilitiesFactory.CreateAbilityFor(_entity, AbilitiyConfig);
            _entity.Abilities.Add(ability);
        }

        private void OnViewClicked() => Selected?.Invoke(this);
    }
}
