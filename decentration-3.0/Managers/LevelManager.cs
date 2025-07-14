using Godot;
using PVZModel.Static.LevelConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers
{
    public static class LevelManager
    {
        private static readonly PackedScene rainScene;
        private static CpuParticles2D rain;

        private static double passedTime;
        private static bool raining;

        private static bool _isRainCautionShowed = false;
        static LevelManager()
        {
            rainScene = GD.Load<PackedScene>("res://Rain/rain_animation.tscn");
            rain = rainScene.Instantiate<CpuParticles2D>();
            GameManager.Instance.AddChild(rain);
        }

        public static void Process(double delta)
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

        private static void Sun()
        {
            rain.Emitting = false;
            GameManager.weather = WeatherType.Sun;
        }

        private static void Rain()
        {           
            rain.Emitting = true;
            GameManager.weather = WeatherType.Rain;

            if(!_isRainCautionShowed)
            {
                _isRainCautionShowed = true;

                PackedScene rainCautionScene = GD.Load<PackedScene>("res://UIElements/Panels/RainCaution.tscn");
                Node rainCautionNode = rainCautionScene.Instantiate();
                
                GameManager.Instance.AddChild(rainCautionNode);

                Vector2 screenSize = GameManager.Instance.GetViewport().GetVisibleRect().Size;
                Vector2 center = screenSize / 2;

                ((Node2D)rainCautionNode).Position = center;
            }
        }
    }
}
