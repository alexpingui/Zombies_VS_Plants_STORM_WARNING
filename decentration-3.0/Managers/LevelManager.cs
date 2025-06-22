using Godot;
using PVZModel.Static.LevelConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers
{
    public class LevelManager
    {
        private readonly Node parentNode;
        private readonly PackedScene rainScene;
        CpuParticles2D rain;

        private WaveConfig curentWave;


        private float passedTime;
        private bool raining;

        public LevelManager(Node parentNode)
        {
            this.parentNode = parentNode;
            rainScene = GD.Load<PackedScene>("res://Rain/rain_animation.tscn");
            rain = rainScene.Instantiate<CpuParticles2D>();
            parentNode.AddChild(rain);
        }

        public void Process(float delta)
        {
            passedTime += delta;
            if (passedTime >= 10)
            {
                raining = !raining;
                passedTime = 0;

                if(raining) Sun();

                else Rain();
            }
        }

        private void Sun()
        {
            rain.Emitting = false;
            GameManager.weather = WeatherType.Sun;
        }

        private void Rain()
        {           
            rain.Emitting = true;
            GameManager.weather = WeatherType.Rain;

        }
    }
}
