using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsometricMonoGame.core
{
    class GameObject
    {
        private Texture2D sprite;
        private Vector2 position;

        protected Vector2 Position
        {
            get => position;
            set => position = value;
        }

        internal GameObject(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Vector2 drawPosition = new Vector2() { X = position.X - sprite.Width / 2, Y = position.Y - sprite.Height / 2 };
            spriteBatch.Draw(sprite, drawPosition, Color.White);
            spriteBatch.End();
        }
    }
}
