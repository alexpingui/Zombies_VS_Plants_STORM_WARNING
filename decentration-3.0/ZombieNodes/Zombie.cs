using DECENTRATION3.Empty.Interfaces;
using Godot;
using PVZModel.Instances.Abstract;
using System;
using static System.Net.Mime.MediaTypeNames;

public partial class Zombie : CharacterBody2D
{
    public ZombieInstance Instance { get; set; }

    private Area2D hitBox;

    protected double _passedTime;

    public override void _Ready()
    {
    }
    public override void _PhysicsProcess(double delta)
	{

    }
}
