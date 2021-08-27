using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using RPS.Game.Web.Models;

namespace RPS.Game.Web.Components.Player
{
    public partial class PlayerViewModel : ComponentBase
    {
        public string SelectedOption { get; set; }
        [Parameter]
        public bool Played { get; set; }

        [Parameter]
        public PlayerOption[] PlayerOptions { get; set; }

        [Parameter]
        public EventCallback<string> OnPlayerSelection { get; set; }

        protected async Task SelectOptionClick(string selectedOption)
        {
            if (!Played)
            {
                SelectedOption = selectedOption;
                OnPlayerSelection.InvokeAsync(SelectedOption);
            }
        }

    }
}