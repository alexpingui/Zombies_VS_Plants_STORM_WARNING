using DECENTRATION3.Empty.PlantNodes.ShootPlant;
using Godot;
using System;

public partial class PeaShooter : ShootingPlant
{
    protected override string BulletScenePath => "res://PlantNodes/Particles/Bullets/Pea.tscn";
    public override void _Ready()
	{
		base._Ready();
		Health = 100;
		CoolDown = 5.5;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}
	public void AnimationFinished(string name)
	{
		base.SetDefaultAnimation();
	}
}
