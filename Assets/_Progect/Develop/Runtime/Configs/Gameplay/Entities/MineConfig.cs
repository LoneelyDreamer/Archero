using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewMineConfig", fileName = "MineConfig")]
    public class MineConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Mine";     
        [field: SerializeField, Min(0)] public float AOEDamage { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float AOERadius { get; private set; } = 4;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 0.2f;
        [field: SerializeField, Min(0)] public float SelfDetonationTime { get; private set; } = 0.5f;
        [field: SerializeField] public bool IsDetonatingOnInstall { get; private set; } = false;
    }
}
