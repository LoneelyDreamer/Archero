using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Configs.Meta.ShopPrises
{
    [CreateAssetMenu(menuName = "Configs/Meta/ShopPricesConfig", fileName = "ShopPricesConfig")]
    public class ShopPricesConfig : ScriptableObject
    {
        [field: SerializeField] public int ResetPrice { get; private set; }
    }

}
