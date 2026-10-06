using Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.StatsFeature;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using System.Collections.Generic;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrenceTypes, int> WalletData;
        public List<int> CompletedLevels;
        public Dictionary<StatTypes,int> StatsUpgradeLevel;
    }
}
