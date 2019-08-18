using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsometricMonoGame.core
{
    internal static class PlayerInputFactory
    {
        internal static IPlayerInput Create()
        {
            return new GamePadPlayerInput();
        }
    }
}
