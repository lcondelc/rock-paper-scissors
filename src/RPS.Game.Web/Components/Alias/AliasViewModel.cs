using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace RPS.Game.Web.Components.Alias
{
    public partial class AliasViewModel : ComponentBase
    {
        public string Name { get; set; }
        public bool HasName { get; set; }
        [Parameter]
        public EventCallback<string> OnPlayerNameSet { get; set; }
        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            HasName = args.Key == "Enter" && !string.IsNullOrWhiteSpace(Name);
            OnPlayerNameSet.InvokeAsync(Name);
        }
    }
}