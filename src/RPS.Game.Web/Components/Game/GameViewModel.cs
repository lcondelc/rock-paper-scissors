using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;
using RPS.Game.Web.Models;
using RPS.Game.Web.Services;
using System.Linq;

namespace RPS.Game.Web.Components.Game
{
    public partial class GameViewModel : ComponentBase
    {
        [Inject]
        private PlayerOptionsService PlayerOptionsService { get; set; }

        public bool StartAgain { get; set; }
        public string SelectedOption { get; set; }
        public string MachineOption { get; set; }
        public int PlayerCount { get; set; }
        public int MachineCount { get; set; }
        public bool IsWinner { get; set; }
        public string WinnerText { get; set; }
        public string PlayerName { get; set; }

        public PlayerOption[] PlayerOptions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PlayerOptions = await PlayerOptionsService.GetOptions();
        }

        public void OnPlayerSelection(string e)
        {
            SelectedOption = e;
            if (MachineOption == SelectedOption)
            {
                StartAgain = true;
                return;
            }

            var option = PlayerOptions.Where(x => x.Name == SelectedOption).FirstOrDefault();
            var result = option.Beats.Where(x => x == MachineOption).Any();

            if (result)
                PlayerCount++;
            else
                MachineCount++;

            if (PlayerCount == 3)
            {
                ResetCounters(true);
            }
            else if (MachineCount == 3)
            {
                ResetCounters(false);
            }

            StartAgain = true;
        }
        private void ResetCounters(bool playerIsWinner)
        {
            PlayerCount = 0;
            MachineCount = 0;
            var winnerText = playerIsWinner ? PlayerName : "Machine";
            WinnerText = $"{winnerText} Wins!!!";
            IsWinner = true;
        }

        public void OnMachineSelection(string e)
        {
            MachineOption = e;
        }

        public void OnPlayerNameSet(string e)
        {
            PlayerName = e;
        }
    }
}