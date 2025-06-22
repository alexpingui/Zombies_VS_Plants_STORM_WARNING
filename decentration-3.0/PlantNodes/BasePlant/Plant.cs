using Godot;
using System;

public partial class Plant : Area2D
{
    protected AnimationPlayer animationPlayer;
    protected double timePassed;
    public override void _Ready()
	{
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

	public override void _Process(double delta)
	{
        timePassed += delta;
	}
    
}
