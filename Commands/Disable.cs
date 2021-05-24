using CommandSystem;
using GamemodeManager.API;
using System;

namespace GamemodeManager.Commands
{
    public class Disable : ICommand
    {
        public Disable(CustomGamemode gamemode) => AssignedGamemode = gamemode;

        readonly CustomGamemode AssignedGamemode;

        public string Command => "disable";

        public string[] Aliases => new string[] { "dis" };

        public string Description => $"Disables the {AssignedGamemode.Name} gamemode by {AssignedGamemode.Author}.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
