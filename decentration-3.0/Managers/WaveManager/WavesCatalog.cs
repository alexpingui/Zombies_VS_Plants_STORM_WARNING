using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers.WaveManager
{
    public static class WavesCatalog
    {
        public static List<Wave> _waves;

        static WavesCatalog()
        {
            _waves =
            [
                // 🌊 Волна 1 — обучение, один зомби в начале
                new Wave
            {
                zombieSpawns =
                [
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 30 }, // Первая волна начинается через 20 сек
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 1, Delay = 15 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 3, Delay = 15 }
                ]
            },

            // 🌊 Волна 2 — мягкое давление
            new Wave
            {
                zombieSpawns =
                [
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 0, Delay = 15 }, 
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 4, Delay = 12 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 12 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 0, Delay = 5 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 3, Delay = 5 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 4, Delay = 10 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 0, Delay = 0 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 0, Delay = 1 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 1, Delay = 1 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 1 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 3, Delay = 0 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 4, Delay = 1 }
                ]
            },

            // 🌊 Волна 3 — уже надо обороняться
            new Wave
            {
                zombieSpawns =
                [
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 1, Delay = 30 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 10 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 3, Delay = 10 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 4, Delay = 10 }
                ]
            },

            // 🌊 Волна 4 — нападение по фронту
            new Wave
            {
                zombieSpawns =
                [
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 0, Delay = 35 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 1, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 3, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 4, Delay = 8 }
                ]
            },

            // 🌊 Волна 5 — финал (но честный)
            new Wave
            {
                zombieSpawns =
                [
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 40 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 1, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 0, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 3, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 4, Delay = 8 },
                    new ZombieSpawnConfig { ZombieType = ZombieType.DefaultZombie, Line = 2, Delay = 10 }
                ]
            }
            ];
        }
    }
}
