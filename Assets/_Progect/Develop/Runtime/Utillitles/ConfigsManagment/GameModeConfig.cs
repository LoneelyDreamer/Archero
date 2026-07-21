using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles.ConfigsManagment
{
    [CreateAssetMenu(menuName = "HomeWork", fileName = "GameMode")]
    public class GameModeConfig : ScriptableObject
    {
        [field: SerializeField] public string Chars {  get; private set; }
        [field: SerializeField] public string Numbers {  get; private set; }
    }
}
