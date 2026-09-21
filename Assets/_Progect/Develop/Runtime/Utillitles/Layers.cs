using UnityEngine;

namespace Assets._Progect.Develop.Runtime.Utillitles
{
    public class Layers
    {
        public static readonly int Characters = LayerMask.NameToLayer("Characters");
        public static readonly LayerMask CharactersMask = 1 << Characters;

        public static readonly int Enviroment = LayerMask.NameToLayer("Enviroment");
        public static readonly LayerMask EnviromentMask = 1 << Enviroment;
    }
}
