using Godot;
using PVZModel;
using PVZModel.Static.Entities;
using PVZModel.Static.Entities.Abstract;
using PVZModel.Static.LevelConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.ZombieNodes
{
    public class ZombieManager 
    {
        private float passedTime;
        private LevelConfig currentLevel;
        private WaveConfig currentWave;
        private Dictionary<ZombieSpawnGroup, int> spawnIndexes;
        private int waveInd;

        private Node parentNode;
        private PackedScene zombieScene;

        public ZombieManager(Node parentNode)
        {
            this.parentNode = parentNode;
            zombieScene = GD.Load<PackedScene>($"res://ZombieNodes/zombie.tscn");
            currentLevel = LevelCatalog.Levels.First();
            spawnIndexes = [];
        }

        public void Process(float delta)
        {            
            if (currentWave == null || currentWave.Duration <= passedTime)
            {
                passedTime = 0;
                currentWave = null;

                if (currentLevel.Waves.Count > waveInd)
                {
                    currentWave = currentLevel.Waves[waveInd];
                    spawnIndexes.Clear();
                    foreach (var group in currentWave.ZombieSpawns)
                    {
                        spawnIndexes[group] = 0;
                    }
                    waveInd++;
                }
                else return;
            }

            foreach (var group in currentWave.ZombieSpawns)
            {
                if (spawnIndexes[group] < passedTime / group.Delay)
                {
                    Zombie zombie = zombieScene.Instantiate<Zombie>();
                    zombie.Instance = ZombieCatalog.GetZombie(nameof(DefaultZombie)).GetInstance();
                    zombie.Position = new Vector2(1800, GameManager.groundPosition.Y + (group.Lane * 128));
                    parentNode.AddChild(zombie);

                    spawnIndexes[group]++;

                }
            }
            passedTime += delta;
        }
    }
}
