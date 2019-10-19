using IsometricMonoGame.core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsometricMonoGame.Core
{
    internal class Mine : GameObject
    {
        private const string spriteName = "mines";
        internal Mine(GameCore game, Vector2 position) : base(game, spriteName, position) { }
    }
}
