using Godot;
using PVZModel.Static.LevelConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers.WaveManager
{
    public static class WaveManager
    {
        private static double _passedTime;

        public static int AliveZombies;

        private static Wave currentWave;
        private static ZombieSpawnConfig currentZombieSpawnConfig;
        public static void Process(double delta)
        {
            _passedTime += delta;

            if (WavesCatalog._waves.Count > 0)
            {
                currentWave = WavesCatalog._waves[0];
                if (currentWave.zombieSpawns.Count > 0)
                {
                    currentZombieSpawnConfig = currentWave.zombieSpawns[0];
                    if (_passedTime >= currentZombieSpawnConfig.Delay)
                    {
                        _passedTime = 0;
                        GameManager.Instance.AddChild(CreateZombie(currentZombieSpawnConfig.ZombieType, currentZombieSpawnConfig.Line));
                        currentWave.zombieSpawns.RemoveAt(0);
                    }
                }
                else
                {
                    WavesCatalog._waves.RemoveAt(0);
                    _passedTime = 0;
                }
            }
            else if (WavesCatalog._waves.Count == 0 && ZombieManager.zombies.Count == 0) GameManager.Instance.EndGame();
        }
        
        public static Node2D CreateZombie(ZombieType zombieType, int line)
        {
            switch(zombieType)
            {
                case ZombieType.DefaultZombie:
                    {
                        var zombieScene = GD.Load<PackedScene>("res://ZombieNodes/DefaultZombie.tscn");
                        var zombieNode = zombieScene.Instantiate();

                        if (zombieNode is DefaultZombie defaultZombie)
                        {
                            defaultZombie.Position = GetLine(line);
                            defaultZombie.Line = currentZombieSpawnConfig.Line;
                            ZombieManager.zombies.Add(defaultZombie);

                            return defaultZombie;
                        }
                    }
                    break;
            }
            return null;
        }

        private static Vector2 GetLine(int line)
        {
            float y = GameManager.groundPosition.Y + 128 * line;
            return new Vector2(2100, y);
        }
    }
}
