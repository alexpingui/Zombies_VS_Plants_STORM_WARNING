using DECENTRATION3.Empty.Interfaces;
using Godot;
using System;
using static Godot.TextServer;

public abstract partial class Bullet : Particle, IAttacker
{
	protected abstract float Speed { get;}
    public virtual int Damage { get => Damage; }

    protected IDamageable zombie;
    public override void _Ready()
	{
        
	}

	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X + Speed * (float)delta, Position.Y);
        if (Position.X >= 1795) QueueFree();
    }

    public void OnBodyEntered(Node2D body)
	{
        if (body is IDamageable damageableBody)
        {
            Attack(damageableBody);
			QueueFree();
        }
    }

    public void Attack(IDamageable damageableBody)
    {
        damageableBody.TakeDamage(Damage);
    }
}
