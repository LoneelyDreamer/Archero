using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.InputFeatures
{
    public interface IInputService
    {
        bool IsEnabled { get; set; }

        Vector3 Direction { get; }

        Vector3 MousePosition { get; }

        bool IsAttackPressed { get; }
    }
}
