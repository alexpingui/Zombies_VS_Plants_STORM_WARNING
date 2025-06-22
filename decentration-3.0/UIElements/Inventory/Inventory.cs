using Godot;
using System;
using System.Collections.Generic;

public partial class Inventory : Control
{
	private Label _sunsQuantityLabel;
	private HBoxContainer _plantCardsContainer;
	public override void _Ready()
	{
		_sunsQuantityLabel = GetNode<Label>("InventorySprite/MarginContainer2/VBoxContainer/SunsQuantityLabel");
        _plantCardsContainer = GetNode<HBoxContainer>("InventorySprite/MarginContainer/PlantCardsHBoxContainer");
	}
	public override void _Process(double delta)
	{
	}
	public void FillInventory(List<PlantType> plantTypes)
	{
		foreach (var plantType in plantTypes)
		{
            var cardScene = GD.Load<PackedScene>("res://PlantCard/plant_card_button.tscn");
            var cardInstance = cardScene.Instantiate<PlantCard>();
            cardInstance.plant = plantType;

            _plantCardsContainer.AddChild(cardInstance);
        }
			
	}
	public void UpdateSuns(int suns)
	{
		_sunsQuantityLabel.Text = suns.ToString();
	}
}
