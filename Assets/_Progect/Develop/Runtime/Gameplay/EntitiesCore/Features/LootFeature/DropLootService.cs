using Assets._Progect.Develop.Runtime.Configs.Gameplay.Loot;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.LootFeature
{
    public class DropLootService
    {
        private LootListConfig _lootListConfig;
        private LootFactory _lootFactory;

        public DropLootService(LootListConfig lootListConfig, LootFactory lootFactory)
        {
            _lootListConfig = lootListConfig;
            _lootFactory = lootFactory;
        }

        public void DropLootFor(Entity entity)
        {
            Transform entityTransform = entity.Transform;

            List<ExperienceLootConfig> expConfigs = _lootListConfig.LootConfigs
                .Where(loot => loot.GetType() == typeof(ExperienceLootConfig))
                .Cast<ExperienceLootConfig>()
                .ToList();

            if (expConfigs.Count > 0)
                DropExp(entityTransform.position, expConfigs[Random.Range(0, expConfigs.Count)]);

            DropCoins(entityTransform.position);
            DropHealth(entityTransform.position);          
        }

       

        private void DropExp(Vector3 position, ExperienceLootConfig experienceLootConfig)
        {
            int expInOnePotion = 300;

            if (experienceLootConfig.Experience < expInOnePotion) 
            {
                _lootFactory.CreateExperienceLoot(experienceLootConfig.PrefabPath, position, experienceLootConfig.Experience);
            }
            else
            {
                int restOfExp = (int)experienceLootConfig.Experience % expInOnePotion;
                int pointNumbers = ((int)experienceLootConfig.Experience - restOfExp) / expInOnePotion;

                for (int i = 0; i < pointNumbers; i++)
                {
                    _lootFactory.CreateExperienceLoot(experienceLootConfig.PrefabPath, position, expInOnePotion);
                }
            }
        }

        private void DropCoins(Vector3 position)
        {
            List<CoinLootConfig> coinsLootConfigs = _lootListConfig.LootConfigs
                 .Where(loot => loot.GetType() == typeof(CoinLootConfig))
                 .Cast<CoinLootConfig>()
                 .ToList();

            if(coinsLootConfigs.Count > 0 && Random.Range(0,100) > 50)
            {
                CoinLootConfig coinLootConfig = coinsLootConfigs[Random.Range(0, coinsLootConfigs.Count)];

                _lootFactory.CreateCoinsLoot(coinLootConfig.PrefabPath, position, coinLootConfig.Coins);
            }
        }

        private void DropHealth(Vector3 position)
        {
            List<HealthLootConfig> healthLootConfigs = _lootListConfig.LootConfigs
            .Where(loot => loot.GetType() == typeof(HealthLootConfig))
            .Cast<HealthLootConfig>()
            .ToList();

            if (healthLootConfigs.Count > 0 && Random.Range(0, 100) > 50)
            {
                HealthLootConfig healthLootConfig = healthLootConfigs[Random.Range(0, healthLootConfigs.Count)];

                _lootFactory.CreateHealthLoot(healthLootConfig.PrefabPath, position, healthLootConfig.Health);
            }
        }

     
    }
}
