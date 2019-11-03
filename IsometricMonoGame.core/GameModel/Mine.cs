using Microsoft.Xna.Framework;

namespace MonoGame.Core.GameModel
{
    internal class Mine : GameObject
    {
        internal const string CommonSpriteName = "mines";

        internal Mine(Vector2 position) : base(CommonSpriteName, position) { }
    }
}
