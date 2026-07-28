using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Rendering.DebugUI;

namespace Assets._Progect.Develop.Runtime.Meta.Feathers.Caunter
{
    public class WinAndLoseCauntersServise : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<CauntersTypes, ReactiveVeriable<int>> _caunters;

        public WinAndLoseCauntersServise(Dictionary<CauntersTypes, ReactiveVeriable<int>> caunters, PlayerDataProvider playerDataProvider)
        {
            _caunters = caunters;
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public List<CauntersTypes> AvalableCaunters => _caunters.Keys.ToList();

        public void Caunt(CauntersTypes type)
        {
            _caunters[type].Value += 1;
        }

        public void ResetCaunters()
        {
            foreach (KeyValuePair<CauntersTypes, ReactiveVeriable<int>> cunts in _caunters)
                _caunters[cunts.Key].Value = 0;
        }

        public IReadOnlyVeriable<int> GetCaunter(CauntersTypes type) => _caunters[type];


        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<CauntersTypes, int> cunts in data.CauntersData)
                if (_caunters.ContainsKey(cunts.Key))
                    _caunters[cunts.Key].Value = cunts.Value;
                else
                    _caunters.Add(cunts.Key, new ReactiveVeriable<int>(cunts.Value));
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<CauntersTypes, ReactiveVeriable<int>> cunts in _caunters)
                if (data.CauntersData.ContainsKey(cunts.Key))
                    data.CauntersData[cunts.Key] = cunts.Value.Value;
                else
                    data.CauntersData.Add(cunts.Key, cunts.Value.Value);
        }
    }
}
