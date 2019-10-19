using IsometricMonoGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsometricMonoGame.core
{
    internal abstract class GameObject
    {
        private string spriteName;
        private GameCore game;

        protected Vector2 Position { get; set; }

        internal GameObject(GameCore game, string spriteName, Vector2 position)
        {
            this.game = game;
            this.spriteName = spriteName;
            this.Position = position;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            Texture2D sprite = game.SpritesStorage[spriteName];
            Vector2 drawPosition = new Vector2() { X = Position.X - sprite.Width / 2, Y = Position.Y - sprite.Height / 2 };
            spriteBatch.Draw(sprite, drawPosition, Color.White);
        }
    }
}
