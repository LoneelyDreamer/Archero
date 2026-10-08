using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot
{
    public class InstantShootDirectionArgs
    {
        private int _angel;
        private int _projectileCount;

        public InstantShootDirectionArgs(int angel, int projectileCount)
        {
            _angel = angel;
            _projectileCount = projectileCount;
        }

        public int Angel => _angel;

        public int ProjectileCount
        {
            get => _projectileCount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _projectileCount = value;
            }
        }
    }
}
