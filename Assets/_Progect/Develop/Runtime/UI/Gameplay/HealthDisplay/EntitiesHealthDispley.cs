using Assets._Progect.Develop.Runtime.UI.CommonView;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay.HealthDisplay
{
    public class EntitiesHealthDispley : ElementsListView<BarWithText>
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
