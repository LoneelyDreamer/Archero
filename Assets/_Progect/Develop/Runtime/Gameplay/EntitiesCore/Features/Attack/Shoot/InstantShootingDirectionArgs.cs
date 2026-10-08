using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Progect.Develop.Runtime.Gameplay.EntitiesCore.Features.Attack.Shoot
{
    public class InstantShootingDirectionArgs
    {
        private List<InstantShootDirectionArgs> _args;

        public InstantShootingDirectionArgs(params InstantShootDirectionArgs[] args)
        {
            _args = new List<InstantShootDirectionArgs>(args);
        }

        public IReadOnlyList<InstantShootDirectionArgs> Args => _args;

        public void Add(InstantShootDirectionArgs shootingDirectionArgs)
        {
            var arg = _args.FirstOrDefault(ar => ar.Angel == shootingDirectionArgs.Angel);

            if (arg != null)
            {
                arg.ProjectileCount += shootingDirectionArgs.ProjectileCount;
                return;
            }

            _args.Add(shootingDirectionArgs);
        }

        public void Remove(InstantShootDirectionArgs shootingDirectionArgs)
        {
            var arg = _args.FirstOrDefault(ar => ar.Angel == shootingDirectionArgs.Angel);

            if (arg != null)
            {
                arg.ProjectileCount -= shootingDirectionArgs.ProjectileCount;   
                
                if(arg.ProjectileCount <= 0)
                    _args.Remove(shootingDirectionArgs);
            }
        }
    }
}
