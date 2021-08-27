using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using RPS.Game.Web.Models;
using RPS.Game.Web.Services;

namespace RPS.Game.Web.Components.Machine
{
    public partial class MachineViewModel : ComponentBase
    {
        [Inject]
        private MachineService MachineService { get; set; }

        [Parameter]
        public PlayerOption[] MachineOptions { get; set; }

        [Parameter]
        public bool Played { get; set; }

        [Parameter]
        public string ImageUrl { get; set; }

        [Parameter]
        public bool StartAgain { get; set; }

        public PlayerOption MachineSelectedOption { get; set; }

        [Parameter]
        public EventCallback<PlayerOption> OnMachineSelection { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ImageUrl = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/b680a062246147.5a8a773c6932d.gif";
            MachineStart(false);
        }

        private async void MachineStart(bool Played)
        {
            int option = await MachineService.GetRandomOption(0, MachineOptions.Length);
            MachineSelectedOption = MachineOptions[option];
            await OnMachineSelection.InvokeAsync(MachineSelectedOption);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (StartAgain)
            {
                if (!Played)
                    MachineStart(Played);
                StartAgain = false;
            }
        }
    }
}