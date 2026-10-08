using Assets._Progect.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
    
namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Abilities
{
    public class StatChangedAbility : Ability
    {
        private Entity _entity;
        private StatChangedAbilityConfig _config;

        public StatChangedAbility(Entity entity, 
            StatChangedAbilityConfig config,
            int currentLevel) : base(config.ID, currentLevel, config.MaxLevel)
        {
            _entity = entity;
            _config = config;
        }

        public override void Actvate()
        {
            _entity.StatsEffects.Add(new StatsEffect(_config.StatType, _config.GetApplyEffect()));
        }
    }
}
