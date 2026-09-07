using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
using Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures
{
    public class ClickService
    {
        private readonly Camera _camera;
        private readonly CollidersRegestryService _collidersRegestry;
        private readonly MainHeroHolderService _mainHeroHolder;
        private readonly IInputService _inputService;
        private readonly EntitiesFactory _entitiesFactory;
        private readonly ConfigsProviderServise _configsProviderServise;

        private MineConfig _mineConfig;

        public ClickService(
                CollidersRegestryService collidersRegestry,
                MainHeroHolderService mainHeroHolder,
                IInputService inputService,
                EntitiesFactory entitiesFactory,
                ConfigsProviderServise configsProviderServise)
        {
            _camera = Camera.main;
            _collidersRegestry = collidersRegestry;
            _mainHeroHolder = mainHeroHolder;
            _inputService = inputService;
            _entitiesFactory = entitiesFactory;
            _configsProviderServise = configsProviderServise;

            _mineConfig = _configsProviderServise.GetConfig<MineConfig>();
        }

        public void Update()
        {
            if (_inputService.IsAttackPressed == false)
                return;

            Entity hero = _mainHeroHolder.MainHero;
            if (hero == null || hero.IsDead.Value)
                return;

            Ray ray = _camera.ScreenPointToRay(_inputService.TouchPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Entity target = _collidersRegestry.GetBy(hit.collider);

                if (target == null)
                    return;

                if (target.TryGetTeam(out ReactiveVeriable<Teams> targetTeam) == false)
                    return;

                if (hero.TryGetTeam(out ReactiveVeriable<Teams> heroTeam) == false)
                    return;

                if (heroTeam.Value == targetTeam.Value)
                    return;

                //if (hero.TryGetInstantAttackDamage(out ReactiveVeriable<float> damage) == false)
                //    return;

                _entitiesFactory.CreateMine(_inputService.TouchPosition, _mineConfig);
                EntitiesHelper.TryTakeDamageFrom(hero, target, 100);
            }

            
        }
    }
}
