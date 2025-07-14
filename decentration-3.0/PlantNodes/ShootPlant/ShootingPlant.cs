using DECENTRATION3.Empty.Interfaces;
using DECENTRATION3.Empty.Managers;
using Godot;
using PVZModel.Static.Entities.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.PlantNodes.ShootPlant
{
    public abstract partial class ShootingPlant : Plant, IDamageable
    {
        protected int Health { get; set; }
        protected int Damage { get; set; }
        protected double CoolDown { get; set; }

        public int Line { get; set; }
        protected abstract string BulletScenePath { get; }

        protected PackedScene bulletScene;


        public override void _Ready()
        {
            base._Ready();
            bulletScene = GD.Load<PackedScene>(BulletScenePath);
        }

        public override void _Process(double delta)
        {
            base._Process(delta);

            if(timePassed >= CoolDown && ZombieManager.zombies.Select(z => z as DefaultZombie).Any(dz => dz != null && dz.Line == this.Line))
            {
                animationPlayer.Play("Shoot");
                
                timePassed = 0;
            }
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;

            if(Health <= 0)
            {
                QueueFree();
                PlantsManager.plants.Remove(Position);
            }
        }
        protected virtual void Shoot()
        {
            var bullet = bulletScene.Instantiate<Area2D>();
            bullet.Position = Position + new Vector2(10, -4);

            GetTree().CurrentScene.AddChild(bullet);
        }
        protected void SetDefaultAnimation()
        {
            animationPlayer.Play("default");
        }
    }
}
