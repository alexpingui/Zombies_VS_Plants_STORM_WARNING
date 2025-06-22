using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECENTRATION3.Empty.Managers
{
    public enum ResourceType
    {
        RainDrop,
        Sun
    }
    public static class ResourcesManager
    {
        public static readonly Dictionary<PlantType, int> Prices = new()
        {
            { PlantType.Sunflower, 50 },
            { PlantType.PeaShooter, 100 },
            { PlantType.Nut, 50 }
        };

        private static int _suns = 50;
        private static int _rainDrops;

        public static void AddSuns(int suns)
        {
            _suns += suns;
            GameManager.Instance.inventory.UpdateSuns(_suns);
        }
        public static void AddRainDrops(int rainDrops)
        {
            _rainDrops += rainDrops;
        }
        public static bool TryBuyPlant(PlantType plantType)
        {
            if (Prices[plantType] <= _suns)
            {
                _suns -= Prices[plantType];
                GameManager.Instance.inventory.UpdateSuns(_suns);
                return true;
            }
            else return false;
        }
    }
}
