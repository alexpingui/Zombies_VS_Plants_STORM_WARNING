using DECENTRATION3.Empty.Managers;
using DECENTRATION3.Empty.Managers.WaveManager;
using Godot;
using PVZModel.Static.LevelConfig;
using System;
using System.Collections.Generic;
using System.Drawing;

public partial class GameManager : Node2D
{
    public static GameManager Instance;

    public static Vector2 MousePosition;

    private static PlantType _selectedPlant;

    public static WeatherType weather;


    public Inventory inventory;

    public static Vector2 groundPosition;

    public override void _Ready()
    {
        Instance = this;

        weather = WeatherType.Sun;
        groundPosition = GetGroundPosition();

        inventory = GetNode<Inventory>("Inventory");
        inventory.FillInventory(new List<PlantType>
                                {
                                    PlantType.PeaShooter,
                                    PlantType.Sunflower,
                                    PlantType.Nut
                                });
    }

    public static void SetSelectedPlant(PlantType plant)
    {
        _selectedPlant = plant;
        PlantsManager.IsPlantCardSelected = true;
        PlantsManager.IsShovelPicked = false;
    }

    public override void _Input(InputEvent eventik)
    {
        if (eventik is InputEventMouseButton mouseButton)
        {       
            if (mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left)
            {
                MousePosition = mouseButton.Position;

                if (PlantsManager.IsPlantCardSelected)
                {
                    PlantsManager.CreatePlant(_selectedPlant);
                }
                if(PlantsManager.IsShovelPicked)
                {
                    PlantsManager.RemovePlant();
                }
            }
        }
    }
    public override void _Process(double delta)
    {
        LevelManager.Process(delta); 
        WaveManager.Process(delta);
    }

    private Vector2 GetGroundPosition()
    {
        var ground = GetNode<Sprite2D>("Map/Grounds");

        float groundPosX = ground.Position.X;
        float groundPosY = ground.Position.Y;

        Vector2 groundPosition = new Vector2(groundPosX, groundPosY);
        return groundPosition;
    }

    public void EndGame()
    {
        GetTree().Quit();
    }
}
