using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EscapeReloaded
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
