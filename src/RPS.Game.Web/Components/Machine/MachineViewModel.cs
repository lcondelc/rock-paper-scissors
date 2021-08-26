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
        public bool StartAgain { get; set; }

        public PlayerOption MachineSelectedOption { get; set; }

        [Parameter]
        public EventCallback<string> OnMachineSelection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MachineStart();
        }

        private async void MachineStart()
        {
            int option = await MachineService.GetRandomOption(0, MachineOptions.Length);
            MachineSelectedOption = MachineOptions[option];
            await OnMachineSelection.InvokeAsync(MachineSelectedOption.Name);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (StartAgain)
            {
                MachineStart();
                StartAgain = false;
            }
        }

    }
}