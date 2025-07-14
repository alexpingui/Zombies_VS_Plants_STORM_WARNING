using DECENTRATION3.Empty.Interfaces;
using Godot;
using System;

public partial class LawnMower : CharacterBody2D, IAttacker
{
	private const float _speed = 200.0f;
    private bool _isActivated;

    public int Damage => 10000;

    public override void _Ready()
    {
        base._Ready();
        Velocity = new Vector2(_speed, 0);
    }

    public override void _PhysicsProcess(double delta)
	{
		if(_isActivated)
		{
            MoveAndSlide();

            if (Position.X >= 1650)
            {
                QueueFree();
            }
		}
	}

	public void On2DAreaEntered(Area2D area)
	{
        if (area.GetParent() is IDamageable damageableBody)
        {
            _isActivated = true;
            Attack(damageableBody);
        }
    }

    public void Attack(IDamageable damageableBody)
    {
        damageableBody.TakeDamage(Damage);
    }
}
