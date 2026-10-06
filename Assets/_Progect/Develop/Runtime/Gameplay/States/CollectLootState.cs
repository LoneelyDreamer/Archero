using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.MainHero;
using Assets._Progect.Develop.Runtime.Utillitles.StateMachineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.States
{
    public class CollectLootState : State, IUpdatableState
    {
        private LootPullingService _lootPullingService;
        private MainHeroHolderService _mainHeroHolderService;

        public CollectLootState(
            LootPullingService lootPullingService,
            MainHeroHolderService mainHeroHolderService)
        {
            _lootPullingService = lootPullingService;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public override void Enter()
        {
            base.Enter();

            _lootPullingService.PullTo(_mainHeroHolderService.MainHero);
        }

        public override void Exit()
        {
            base.Exit();

            _lootPullingService.Reset();
        }

        public void Update(float deltaTime)
        {
        }
    }
}
