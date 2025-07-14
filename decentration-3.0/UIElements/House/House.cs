using Godot;
using System;

public partial class House : Area2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void HouseAreaEntered(Area2D area)
	{
		if(area.GetParent() is Zombie zombie) 
		{
            GameManager.Instance.EndGame();
        }
	}
}
