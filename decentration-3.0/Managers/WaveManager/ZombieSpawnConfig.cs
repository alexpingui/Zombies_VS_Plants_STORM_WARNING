using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers.WaveManager
{
    public enum ZombieType
    {
        DefaultZombie,
        EminemZombie,
        FunnelZombie,
        BucketZombie
    }
    public class ZombieSpawnConfig
    {
        public ZombieType ZombieType { get; init; }
        public int Line { get; init; }
        public double Delay { get; init; }
    }
}
