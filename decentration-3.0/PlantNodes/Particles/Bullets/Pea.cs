using Godot;
using System;

public partial class Pea : Bullet
{
	protected override float Speed => 100;

    public override int Damage => 35;

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
