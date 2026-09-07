using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.TeamsFactory;
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

        public ClickService(
                CollidersRegestryService collidersRegestry,
                MainHeroHolderService mainHeroHolder,
                IInputService inputService)
        {
            _camera = Camera.main;
            _collidersRegestry = collidersRegestry;
            _mainHeroHolder = mainHeroHolder;
            _inputService = inputService;
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

                EntitiesHelper.TryTakeDamageFrom(hero, target, 100);
            }
        }
    }
}
