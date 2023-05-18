using BallisticTrajectoryCalculator.Models;
using Newtonsoft.Json;

namespace BallisticTrajectoryCalculator.Services
{
    public static class BulletJsonParser
    {
        public static Dictionary<string, BulletParameters> Parse(string filePath = "./Data/Bullets.json")
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, BulletParameters>>(jsonString);
        }
    }
}
