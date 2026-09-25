using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.HealthDisplay
{
    public class EntityHealthPrethenter : IPresentor
    {
        private BarWithText _bar;
        private Entity _entity;
        private ReactiveVeriable<Teams> _team;
        private ReactiveVeriable<float> _health;
        private ReactiveVeriable<float> _maxHealth;

        private List<IDisposable> _disposables = new();

        public EntityHealthPrethenter(BarWithText bar, Entity entity)
        {
            _bar = bar;
            _entity = entity;
        }

        public BarWithText Bar => _bar;

        public void Initialise()
        {
            _health = _entity.CurrentHealth;
            _maxHealth = _entity.MaxHealth;
            _team = _entity.Team;

            _disposables.Add(_health.Subscribe(OnHealthChanged));
            _disposables.Add(_maxHealth.Subscribe(OnMaxHealthChanged));
            _disposables.Add(_team.Subscribe(OnTeamChanged));

            UpdateHealth();
            UpdateFillerColorBy(_team.Value);
        }
              
        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void OnTeamChanged(Teams oldValue, Teams newTeam) => UpdateFillerColorBy(newTeam);

        private void OnMaxHealthChanged(float arg1, float arg2) => UpdateHealth();

        private void OnHealthChanged(float arg1, float arg2) => UpdateHealth();

        private void UpdateHealth()
        {
            _bar.UpdateText(_health.Value.ToString("0"));
            _bar.UpdateSlider(_health.Value / _maxHealth.Value);
        }

        private void UpdateFillerColorBy(Teams team)
        {
            if (team == Teams.MainHero)
                _bar.SetFillerColor(Color.green);
            else if(team == Teams.Enemies)
                _bar.SetFillerColor(Color.red);
        }
    }
}
