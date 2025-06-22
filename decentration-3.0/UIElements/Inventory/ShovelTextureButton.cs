using DECENTRATION3.Empty.Managers;
using Godot;
using System;

public partial class ShovelTextureButton : TextureButton
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

    public override void _Pressed()
    {
        base._Pressed();
        GD.Print("Лопата нажата");
        PlantsManager.IsShovelPicked = true;
    }
}
