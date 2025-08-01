using DECENTRATION3.Empty.PlantNodes.SupportPlants;
using Godot;
using PVZModel.Static.LevelConfig;
using System;

public partial class SunFlower : SupportPlant
{
	private PackedScene _sunScene;

	private Random rnd;

	private double _coolDown;
	public override void _Ready()
	{
		base._Ready();
		rnd = new();
		Health = 60;
		_coolDown = 8;
		_sunScene = GD.Load<PackedScene>("res://PlantNodes/Particles/Resources/Sun.tscn");
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		if(timePassed >= _coolDown && GameManager.weather == WeatherType.Sun)
		{
			animationPlayer.Play("sunning");
			timePassed = 0;
        }
		
	}
    protected void SetDefaultAnimation()
    {
        animationPlayer.Play("default");
    }

	private void Sunning()
	{
        var sun = _sunScene.Instantiate<Area2D>();
		sun.Position = new Vector2(Position.X + rnd.Next(-50, 50), Position.Y);
		GetTree().CurrentScene.AddChild(sun);

		SetDefaultAnimation();
    }
}
