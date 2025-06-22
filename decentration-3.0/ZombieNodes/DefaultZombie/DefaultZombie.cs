using DECENTRATION3.Empty.Interfaces;
using Godot;
using System;

public partial class DefaultZombie : Zombie, IAttacker, IDamageable
{
	protected float _speed = 50.0f;
	protected int _health = 300;

	protected bool isAttacking;

	protected AnimationPlayer animationPlayer;

    public IDamageable currentDamageablePlant;

	public virtual int Damage => 20;

    public override void _Ready()
    {
        base._Ready();

		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

		Velocity = new Vector2(-_speed, 0);
    }
    public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		_passedTime += delta;
		
		if(isAttacking)
		{
            if (!GodotObject.IsInstanceValid((GodotObject)currentDamageablePlant))
			{
                isAttacking = false;
                animationPlayer.Play("Default");
            }

            else if (_passedTime >= 5)
			{
				_passedTime = 0;
				Attack(currentDamageablePlant);
			}
		}
		else
		{
            MoveAndSlide();
        }			
    }
	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health >= 0)
		{
			animationPlayer.Play("Death");
		}
	}
	protected void Death()
	{
		QueueFree();
	}

    public void Attack(IDamageable damageableBody)
    {
		damageableBody.TakeDamage(Damage);
    }
	public void OnHitBoxAreaEntered(Area2D area)
	{
        if (area is IDamageable damageableBody)
		{
			isAttacking = true;
            currentDamageablePlant = damageableBody;
			animationPlayer.Play("Eating");
		}
	}
}
