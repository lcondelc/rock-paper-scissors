using System.Threading.Tasks;
using System.Linq;
using RPS.Game.Web.Models;

namespace RPS.Game.Web.Services
{
    public class PlayerOptionsService
    {
        public async Task<PlayerOption[]> GetOptions()
        {
           return new PlayerOption[]{
                new PlayerOption{
                    Name= "Rock",
                    Image="assets/Rock.png",
                    Beats= new string[] {"Scissors"}
                },
                 new PlayerOption{
                    Name= "Paper",
                    Image="assets/Paper.png",
                    Beats= new string[] {"Rock"}
                },
                 new PlayerOption{
                    Name= "Scissors",
                    Image="assets/Scissors.png",
                    Beats= new string[] {"Paper"}
                }
            };
        }
    }
}