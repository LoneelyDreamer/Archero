using Assets._Progect.Develop.Runtime.Configs.Meta.BonusAndPenalty;
using Assets._Progect.Develop.Runtime.Meta.Feathers.Wallet;

namespace Assets._Progect.Develop.Runtime.Gameplay.BonusAndPenalty
{
    public class BonusAndPenaltyServise
    {
        private WalletServise _walletServise;

        private int _winGoldBonus;
        private int _loseGoldPenalty;

        public BonusAndPenaltyServise(WalletServise walletServise, BonusAndPenaltyStartConfig bonusAndPenaltyStartConfig)
        {
            _walletServise = walletServise;
            _winGoldBonus = bonusAndPenaltyStartConfig.WinGoldBonus;
            _loseGoldPenalty = bonusAndPenaltyStartConfig.LoseGoldPenalty;
        }

        public void AddGoldBonus()
        {
            _walletServise.Add(CurrenceTypes.Gold, _winGoldBonus);
        }

        public void AddGoldPenalty()
        {
            if (_walletServise.Enough(CurrenceTypes.Gold, _loseGoldPenalty))
            {
                _walletServise.Spend(CurrenceTypes.Gold, _loseGoldPenalty);
            }
        }
    }
}
