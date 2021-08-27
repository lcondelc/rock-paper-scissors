using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace RPS.Game.Web.Models
{
    public partial class PlayerOption 
    {
       public string Name { get; set; }
       public string Image { get; set; }
       public string[] Beats { get; set; }
       public bool Played { get; set; }
    }
}