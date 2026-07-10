using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment
{
    [CreateAssetMenu(menuName = "Test", fileName = "TestConfig")]
    public class TestConfig : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
    }
}