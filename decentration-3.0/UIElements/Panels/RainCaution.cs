using Godot;
using System;

public partial class RainCaution : Node2D
{
	public void CloseButtonPressed()
	{
		QueueFree();
	}
}
