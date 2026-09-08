using Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Progect.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures;
using Assets._Progect.Develop.Runtime.Utillitles.Conditions;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using Assets._Progect.Develop.Runtime.Utillitles.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StagesFeature
{
    public class InstallMinesStage : IStage
    {
        private InstallMinesStageConfig _installMinesStageConfig;

        private ReactiveEvent _completed = new();
        private ClickService _clickService;
        private TimerServiceFactory _timerServiceFactory;

        private bool _inProcess;
        private TimerService _timer;
        private IDisposable _disposable;
        public InstallMinesStage(InstallMinesStageConfig installMinesStageConfig, ClickService clickService, TimerServiceFactory timerServiceFactory)
        {
            _installMinesStageConfig = installMinesStageConfig;
            _clickService = clickService;
            _timerServiceFactory = timerServiceFactory;
        }

        public IReadOnlyEvent Completed => _completed;

        public void Cleanup()
        {
            _inProcess = false;

            _clickService.SetRightConfig(_installMinesStageConfig.InstantMine);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        public void Start()
        {
            if (_inProcess)
                throw new InvalidOperationException("Game mod already started");

            _clickService.SetRightConfig(_installMinesStageConfig.Const);

            _inProcess = true;

            _timer = _timerServiceFactory.Create(3f);

            _timer.Restart();
            _disposable = _timer;
        }

        public void Update(float deltaTime)
        {
            if (_timer.IsOveer)
                ProcessEnd();
        }

        private void ProcessEnd()
        {
            Debug.Log("InstallMinesStageEnd");

            _inProcess = false;
            _completed.Invoke();
            _clickService.SetRightConfig(_installMinesStageConfig.InstantMine);
        }
    }
}

