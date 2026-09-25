using Assets._Progect.Develop.Runtime.UI.CommonView;
using Assets._Progect.Develop.Runtime.UI.Core;
using Assets._Progect.Develop.Runtime.UI.Gameplay.HealthDisplay;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextView StageNumberView { get; private set; }
        [field: SerializeField] public EntitiesHealthDispley EntitiesHealthDispley { get; private set; }
    }

}
