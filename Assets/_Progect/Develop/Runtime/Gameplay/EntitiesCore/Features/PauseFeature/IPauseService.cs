using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.PauseFeature
{
    public interface IPauseService
    {
        bool IsPaused { get; }
        void Pause();

        void Unpause();

    }
}
