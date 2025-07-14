using DECENTRATION3.Empty.PlantNodes.SupportPlants;
using Godot;
using System;

public partial class Nut : SupportPlant
{
	private int TotalHealth;
	public override void _Ready()
	{
		base._Ready();
		TotalHealth = 500;
		Health = TotalHealth;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		if(Health <= TotalHealth / 100 * 60)
		{
			if (Health <= TotalHealth / 100 * 30)
			{
				animationPlayer.Play("30PercentLeft");
			}
			else animationPlayer.Play("60PercentLeft");
		}
	}
}
