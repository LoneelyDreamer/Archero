using Assets._Progect.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Enemies;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Infrastructure.DI;
using Assets._Progect.Develop.Runtime.Utillitles.Timer;
using System;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature
{
    public class StagesFactory
    {
        private readonly DIContainer _container;

        public StagesFactory(DIContainer container)
        {
            _container = container;
        }

        public IStage Create(StageConfig stageConfig)
        {
            switch (stageConfig)
            {
                case ClearAllEnemiesStageConfig clearAllEnemiesStageConfig:
                    return new ClearAllEnemiesStage(
                        clearAllEnemiesStageConfig,
                        _container.Resolve<EnemiesFactory>(),
                        _container.Resolve<EntitiesLifeContext>());

                case InstallMinesStageConfig installMinesStageConfig:
                    return new InstallMinesStage(
                        installMinesStageConfig,
                        _container.Resolve<ClickService>(),
                        _container.Resolve<TimerServiceFactory>());

                default:
                    throw new ArgumentException($"Not supported {stageConfig.GetType()} type config");

            }

        }
    }
}
