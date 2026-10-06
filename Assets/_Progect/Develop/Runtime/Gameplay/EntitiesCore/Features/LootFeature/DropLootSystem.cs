using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.System;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class DropLootSystem : IInitializableSystem, IUpdatableSystem
    {
        private DropLootService _dropLootService;

        private ICompositCondition _dropLootCondition;
        private ReactiveVeriable<bool> _lootIsDropped;
        private Entity _entity;

        public DropLootSystem(DropLootService dropLootService)
        {
            _dropLootService = dropLootService;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _lootIsDropped = _entity.LootIsDropped;
            _dropLootCondition = _entity.CanDropLoot;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_dropLootCondition.Evaluate()) 
            {
                DropLoot();
                _lootIsDropped.Value = true;
            }
        }

        private void DropLoot() => _dropLootService.DropLootFor(_entity);


    }
}
