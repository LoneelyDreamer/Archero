using Assets._Progect.Develop.Runtime.Utillitles.Reactivre;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet
{
    public class WalletServise
    {
        private readonly Dictionary<CurrenceTypes, ReactiveVeriable<int>> _currencies;

        public WalletServise(Dictionary<CurrenceTypes, ReactiveVeriable<int>> currencies)
        {
            _currencies = new Dictionary<CurrenceTypes, ReactiveVeriable<int>>(currencies);
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
            if(Enough(type, amount) == false)
                throw new InvalidOperationException("Not enough: " +  type.ToString());

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value -= amount;
        }
    }

}
