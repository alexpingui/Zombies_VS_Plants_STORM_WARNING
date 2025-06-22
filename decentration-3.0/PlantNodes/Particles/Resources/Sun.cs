using Godot;
using System;

public partial class Sun : Resource
{
	public override void _Ready()
	{
		base._Ready();
		Quantity = 25;
		LifeTime = 10;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		
	}
}
