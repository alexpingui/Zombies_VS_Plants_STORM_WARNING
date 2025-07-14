using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers.WaveManager
{
    public class Wave
    {
        public List<ZombieSpawnConfig> zombieSpawns { get; init; }
        public bool IsFinished()
        {
            if (zombieSpawns.Count == 0) return true;

            return false;
        }
    }
}
