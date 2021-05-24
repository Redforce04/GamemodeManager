using GamemodeManager.API;

namespace GamemodeManager.Gamemodes
{
    public class TestGamemode : CustomGamemode
    {
        public override string Name => "TestGamemode";

        public override string Author => "Zereth";

        public override string CommandPrefix => "testgm";
    }
}
