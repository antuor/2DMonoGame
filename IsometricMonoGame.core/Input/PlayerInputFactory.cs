using IsometricMonoGame.Core;

namespace IsometricMonoGame.core.Input
{
    internal static class PlayerInputFactory
    {
        internal static IPlayerInput Create()
        {
            Configuration config = GameCore.Configuration;
            switch (config.ControlDevice)
            {
                case ControlDevice.GamePad: return new GamePadPlayerInput();
                case ControlDevice.Keyboard: return new KeyboardPlayerInput();
                default: throw new System.Exception("Bad device input");
            }
        }
    }
}