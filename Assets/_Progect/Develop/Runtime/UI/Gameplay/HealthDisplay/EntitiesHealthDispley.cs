using Assets._Progect.Develop.Runtime.UI.CommonView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.HealthDisplay
{
    public class EntitiesHealthDispley : ElementsLisyView<BarWithText>
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void UpdatePositionFor(BarWithText bar, Vector3 worldPosition)
        {
            Vector3 position = _camera.WorldToScreenPoint(worldPosition);

            bar.transform.position = position;
        }
    }
}
