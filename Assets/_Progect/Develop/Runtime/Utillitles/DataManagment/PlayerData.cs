using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrenceTypes, int> WalletData;
        public Dictionary<CauntersTypes, int> CauntersData;
        public List<int> CompletedLevels;
    }
}
