using System;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.KeyStorage
{
    public class MapDataKeysStarage : IDataKeySorage
    {
        private readonly Dictionary<Type, string> Keys = new Dictionary<Type, string>()
        {
            {typeof(PlayerData),"PlayrData" },
        };

        public string GetKeyFor<TData>() where TData : ISaveData
            => Keys[typeof(PlayerData)];
    }

}
