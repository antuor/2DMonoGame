using MonoGame.core.GameModel;
using Microsoft.Xna.Framework;

namespace MonoGame.Core.GameModel
{
    internal abstract class GameObject
    {
        private string spriteName;

        protected internal Vector2 Position { get; protected set; }
        internal string SpriteName { get => spriteName; set => spriteName = value; }

        internal GameObject(string spriteName, Vector2 position)
        {
            this.spriteName = spriteName;
            this.Position = position;
        }
    }
}
