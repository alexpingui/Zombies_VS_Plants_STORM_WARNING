using DECENTRATION3.Empty.Managers;
using Godot;
using System;

public partial class Resource : Particle
{
	protected int Quantity;
	protected double LifeTime;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		timePassed += delta;

		if(timePassed >= LifeTime)
		{
			timePassed = 0;
			QueueFree();
		}
	}

	public void OnInputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            switch(this)
			{
				case Sun: ResourcesManager.AddSuns(Quantity);
					break;
			}
			QueueFree();
        }
    }

}
