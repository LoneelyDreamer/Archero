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

        private int _level;

        public SelectableAbilityPresenter(
            AbilitiesFactory abilitiesFactory,
            Entity entity,
            AbilitiyConfig abilitiyConfig,
            SelectableAbilityView view,
            int level)
        {
            _abilitiesFactory = abilitiesFactory;
            _entity = entity;
            AbilitiyConfig = abilitiyConfig;
            View = view;
            _level = level; 
        }

        public AbilitiyConfig AbilitiyConfig { get; }
        public SelectableAbilityView View { get; }

        public void Initialise()
        {
            View.SetName(AbilitiyConfig.Name);
            View.SetDescription(AbilitiyConfig.Discription);
            View.Icon.SetIcon(AbilitiyConfig.Icon);

            InitByAbilityConfig();

            View.Clicked += OnViewClicked;
        }

        public void Dispose()
        {
            View.Clicked -= OnViewClicked;
        }

        public void Provide()
        {
            Ability ability;

            if(AbilitiyConfig.IsUpgradable())
            {
                ability = _entity.Abilities.Elements.FirstOrDefault(abil => abil.ID == AbilitiyConfig.ID);

                if(ability != null)
                {
                    ability.AddLevel(_level);
                    return;                      
                }
            }

           
            ability = _abilitiesFactory.CreateAbilityFor(_entity, AbilitiyConfig, _level);
            _entity.Abilities.Add(ability);
        }

        private void OnViewClicked() => Selected?.Invoke(this);

        private void InitByAbilityConfig()
        {
            if(AbilitiyConfig.IsUpgradable())
            {
                Ability ability = _entity.Abilities.Elements.FirstOrDefault(abil =>abil.ID == AbilitiyConfig.ID);

                if(ability != null)
                {
                    View.Icon.ShowLevel();
                    View.Icon.SetLevel("LV." + ability.CurrentLevel.Value);
                    View.SetTableText("LV." + ability.CurrentLevel.Value + "->" + "LV." + (ability.CurrentLevel.Value + _level));
                }
                else
                {
                    View.Icon.HideLevel();
                    View.SetTableText("NEW LV." + _level);
                }

            }
            else
            {
                View.Icon.HideLevel();
                View.SetTableText("NEW");
            }        
        }
    }
}
