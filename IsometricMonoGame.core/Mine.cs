using IsometricMonoGame.core;
using Microsoft.Xna.Framework;

namespace IsometricMonoGame.Core
{
    internal class Mine : GameObject
    {
        internal const string CommonSpriteName = "mines";

        internal Mine(Vector2 position) : base(CommonSpriteName, position) { }
    }
}
