using Exiled.API.Interfaces;
using System.ComponentModel;

namespace GamemodeManager
{
    public sealed class Config : IConfig
    {
        [Description("Enables the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enables debug logging. Enabled by default for in-dev or pre-release versions.")]
        public bool Debug { get; set; } = true;
    }
}