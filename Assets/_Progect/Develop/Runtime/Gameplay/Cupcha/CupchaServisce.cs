using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Progect.Develop.Runtime.Gameplay.Cupcha
{
    public class CupchaServisce
    {
        public const int MinInclusive = 0;
        public const int MaxExclusive = 10;

        private string _chars;
        private int _leghts;
        private string _cupcha;

        public CupchaServisce(string chars)
        {
            _chars = chars;
        }

        public string GanerateCupcha(int mode)
        {
            _leghts = GetRundomNumber();

            if (_leghts == 0)
                _leghts = 9;

            StringBuilder stringBuilder = new StringBuilder();

            if (mode == 1)
            {
                for (int i = 0; i < _leghts; i++)
                {
                    int random = GetRundomNumber();
                    stringBuilder.Append(random);
                }

                _cupcha = stringBuilder.ToString();

                return _cupcha;
            }
            else if (mode == 2)
            {
                for (int i = 0; i < _leghts; i++)
                {
                    int random = GetRundonChar();
                    stringBuilder.Append(_chars[random]);
                }

                _cupcha = stringBuilder.ToString();

                return _cupcha;

            }

            return stringBuilder.ToString();
        }

        private int GetRundomNumber()
        {
            return Random.Range(MinInclusive, MaxExclusive);
        }

        private int GetRundonChar()
        {
            return Random.Range(0, _chars.Length);
        }

        public bool CupchaCheak(string x)
        {
            if (x == null) return false;

            if (_cupcha == x)
                return true;
            else
                return false;
        }
    }
}
