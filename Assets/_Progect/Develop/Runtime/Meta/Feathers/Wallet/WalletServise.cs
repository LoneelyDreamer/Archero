using Assets._Progect.Develop.Runtime.Utillitles.DataManagment;
using Assets._Progect.Develop.Runtime.Utillitles.DataManagment.DataProviders;
using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet
{
    public class WalletServise : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<CurrenceTypes, ReactiveVeriable<int>> _currencies;

        public WalletServise(Dictionary<CurrenceTypes, ReactiveVeriable<int>> currencies, PlayerDataProvider playerDataProvider)
        {
            _currencies = new Dictionary<CurrenceTypes, ReactiveVeriable<int>>(currencies);
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public List<CurrenceTypes> AvalableCurrencies => _currencies.Keys.ToList();

        public IReadOnlyVeriable<int> GetCurrence(CurrenceTypes type) => _currencies[type];

        public bool Enough(CurrenceTypes type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            return _currencies[type].Value >= amount;
        }

        public void Add(CurrenceTypes type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value += amount;
        }

        public void Spend(CurrenceTypes type, int amount)
        {
            if (Enough(type, amount) == false)
                throw new InvalidOperationException("Not enough: " + type.ToString());

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value -= amount;
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<CurrenceTypes, int> currency in data.WalletData)
                if (_currencies.ContainsKey(currency.Key))
                    _currencies[currency.Key].Value = currency.Value;
                else
                    _currencies.Add(currency.Key, new ReactiveVeriable<int>(currency.Value));

        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<CurrenceTypes, ReactiveVeriable<int>> currency in _currencies)
                if (data.WalletData.ContainsKey(currency.Key))
                    data.WalletData[currency.Key] = currency.Value.Value;
                else
                    data.WalletData.Add(currency.Key, currency.Value.Value);
        }

    }

}
