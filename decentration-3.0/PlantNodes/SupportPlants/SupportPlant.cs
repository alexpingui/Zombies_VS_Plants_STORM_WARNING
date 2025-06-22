using DECENTRATION3.Empty.Interfaces;
using DECENTRATION3.Empty.Managers;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.PlantNodes.SupportPlants
{
    public abstract partial class SupportPlant : Plant, IDamageable
    {
        protected int Health;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            
            if(Health <= 0)
            {
                PlantsManager.plants.Remove(Position);
                QueueFree();
            }
        }
    }
}
