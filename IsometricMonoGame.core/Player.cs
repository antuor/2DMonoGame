using System;
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
            Vector2 direction = new Vector2(0, 0);

            direction = GetKeyboardDirection();

            if (direction.Length() > 0)
                direction.Normalize();

            GamePadThumbSticks gamePadSticks = GamePad.GetState(PlayerIndex.One).ThumbSticks;
            if (gamePadSticks.Left.X != 0 || gamePadSticks.Left.Y != 0)
                direction = new Vector2(gamePadSticks.Left.X, gamePadSticks.Left.Y * -1f);

            Vector2 positionChanged = direction * speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            position += positionChanged;
        }

        private Vector2 GetKeyboardDirection()
        {
            Vector2 direction = new Vector2(0, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                direction += new Vector2(0, 1);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                direction += new Vector2(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                direction += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                direction += new Vector2(1, 0);
            return direction;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, this.position, Color.White);
            spriteBatch.End();
        }
    }
}
