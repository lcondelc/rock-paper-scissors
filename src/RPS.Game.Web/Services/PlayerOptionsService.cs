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
                    Image="https://c0.klipartz.com/pngpicture/390/448/gratis-png-pala-pala-roca-roca-piedra.png",
                    Beats= new string[] {"Scissor"}
                },
                 new PlayerOption{
                    Name= "Paper",
                    Image="https://p7.hiclipart.com/preview/247/72/978/paper-apple-icon-image-format-icon-notes-icon-apple-os-system.jpg",
                    Beats= new string[] {"Rock"}
                },
                 new PlayerOption{
                    Name= "Scissor",
                    Image="https://www.pngfind.com/pngs/m/104-1043327_1600-x-1600-15-black-transparent-scissor-icon.png",
                    Beats= new string[] {"Paper"}
                }
            };
        }
    }
}