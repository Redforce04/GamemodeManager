using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace GamemodeManager
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Redforce04, Zereth";
        public override string Name => "GamemodeManager";
        public override string Prefix => "gamemode_manager";
        public override PluginPriority Priority => PluginPriority.High;
        public override Version RequiredExiledVersion => new Version(2, 10, 0);
        public override Version Version => new Version(1, 0, 0);

        public static Plugin Singleton { get; private set; }

        public override void OnEnabled()
        {
            Singleton = this;

            API.GamemodeManager.LoadGamemodes();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;

            base.OnDisabled();
        }
    }
}
