using Godot;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers
{
    public static class PlantsManager
    {
        private static PackedScene plantScene;
        private static readonly Vector2 groundPosition = GameManager.groundPosition; 
        private static string plantScentPath;

        public static bool IsShovelPicked;

        public static Dictionary<Vector2, Area2D> plants = [];

        public static void CreatePlant(PlantType plantType)
        {
            if (!CheckPositon(GameManager.MousePosition)) return;

            switch(plantType)
            {
                case PlantType.PeaShooter:
                    plantScentPath = "res://PlantNodes/ShootPlant/ShootingPlants/Nodes/PeaShooter.tscn";
                    break;
                case PlantType.Nut:
                    plantScentPath = "res://PlantNodes/SupportPlants/Nut.tscn";
                    break;
                case PlantType.Sunflower:
                    plantScentPath = "res://PlantNodes/SupportPlants/SunFlower.tscn";
                    break;

            }
            plantScene = GD.Load<PackedScene>(plantScentPath);

            Area2D plant = null;

            var cellPosition = GetCellPosition(GameManager.MousePosition);
            
            plant = plantScene.Instantiate<Area2D>();
            plant.Position = new Vector2(cellPosition.X * 128 + 64, cellPosition.Y * 128 + 32) + groundPosition;

            if (!plants.ContainsKey(plant.Position) && ResourcesManager.TryBuyPlant(plantType))
            {
                plants.Add(plant.Position, plant);
                GameManager.Instance.AddChild(plant);
            }
        }

        private static Vector2I GetCellPosition(Vector2 cursor)
        {           
            var local = cursor - groundPosition;

            var column = (int)Math.Floor(local.X / 128);
            var row = (int)Math.Floor(local.Y / 128);

            return new Vector2I(column, row);
        }       

        private static bool CheckPositon(Vector2 position)
        {
            if(position.X < groundPosition.X || position.X > 1575 || position.Y < groundPosition.Y || position.Y > 793)
            return false;

            return true;
        }

        public static void RemovePlant()
        {
            var cellPosition = GetCellPosition(GameManager.MousePosition);
            var plantPosition = new Vector2(cellPosition.X * 128 + 64, cellPosition.Y * 128 + 32) + groundPosition;

            if (plants.ContainsKey(plantPosition))
            {
                plants[plantPosition].QueueFree();
                plants.Remove(plantPosition);
            }
            IsShovelPicked = false;

            GD.Print("Метод удаления растения вызван");
        }
    }

}
