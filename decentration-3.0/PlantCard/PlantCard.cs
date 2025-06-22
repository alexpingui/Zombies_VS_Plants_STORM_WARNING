using Godot;
using System;

public enum PlantType
{
    Sunflower,
    PeaShooter,
    Nut
}

public partial class PlantCard : Button
{
    [Export]
    public PlantType plant;

    private TextureRect _plantImage;
    public override void _Ready()
    {
        _plantImage = GetNode<TextureRect>("TextureRect");
        SetCardVisuals();
        MouseDefaultCursorShape = CursorShape.PointingHand;
    }

    public override void _Pressed()
    {
        GameManager.SetSelectedPlant(plant);
    }

    private void SetCardVisuals()
    {
        _plantImage.Texture = GD.Load<Texture2D>($"res://assets/UI/Card/{plant}Card.png");
    }

}
