using System;
using IsometricMonoGame.core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IsometricMonoGame.Core
{
    internal class Player
    {
        private Texture2D sprite;
        private Vector2 position;
        private Int32 speed = 100;

        internal Player(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        internal void Move(GameTime gameTime)
        {
            Vector2 positionChanged = Input.GetMoveDirection() * speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            position += positionChanged;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, this.position, Color.White);
            spriteBatch.End();
        }
    }
}
