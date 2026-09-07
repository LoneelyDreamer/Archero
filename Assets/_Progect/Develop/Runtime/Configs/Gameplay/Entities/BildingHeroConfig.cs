using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewBildingHeroConfig", fileName = "BildingHeroConfig")]
    public class BildingHeroConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Bilding/Hero";  
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0.5f;
    }
}
