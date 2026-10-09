using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.BounceFeature;
using Assets._Progect.Develop.Runtime.Utillitles;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class BounceProjectileAbility : Ability, IDisposable
    {
        private BounceProgectileAbilityConfig _config;
        private Entity _owner;
        private EntitiesLifeContext _entitiesLifeContext;

        public BounceProjectileAbility(
            BounceProgectileAbilityConfig config,
            Entity owner,
            EntitiesLifeContext entitiesLifeContext,
            int currentLevel) : base(config.ID, currentLevel, config.MaxLevel)
        {
            _config = config;
            _owner = owner;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public override void Actvate()
        {
            _entitiesLifeContext.Added += OnCreaturesAdded;
        }

        private void OnCreaturesAdded(Entity entity)
        {
            if(entity.HasComponent<IsProjectile>() 
                && entity.TryGetOwner(out ReactiveVeriable<Entity> owner)
                && owner.Value == _owner)
            {
                entity
                    .AddBounceEvent()
                    .AddLayerToBounceReaction(_config.LayerBounceRection)
                    .AddBounceCount(new ReactiveVeriable<int>(_config.GetBounceCountBy(CurrentLevel.Value)));

                entity.MustDie.Add(new FuncCondition(() => entity.BounceCount.Value + 1 == 0), 5);

                entity
                    .AddSystem(new BounceDetectorSystem())
                    .AddSystem(new ReflectMovementDirectionOnBouneSystem())
                    .AddSystem(new ReflectRotationDirectionOnBouneSystem())
                    .AddSystem(new BounceCountDecreaseSystem());

            }
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnCreaturesAdded;
        }
    }
}
