using CommandSystem;
using GamemodeManager.API;
using System;

namespace GamemodeManager.Commands
{
    public class Enable : ICommand
    {
        public Enable(CustomGamemode gamemode) => AssignedGamemode = gamemode;

        readonly CustomGamemode AssignedGamemode;

        public string Command => "enable";

        public string[] Aliases => new string[] { "en" };

        public string Description => $"Enables the {AssignedGamemode.Name} gamemode by {AssignedGamemode.Author}.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
