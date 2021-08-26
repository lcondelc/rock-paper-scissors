using System.Threading.Tasks;
using System.Linq;
using System;  
using RPS.Game.Web.Models;

namespace RPS.Game.Web.Services
{
    public class MachineService
    {
        public async Task<int> GetRandomOption(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);  
        }
    }
}