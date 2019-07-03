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
            GamePadDPad gamePad = GamePad.GetState(PlayerIndex.One).DPad;
            GamePadThumbSticks gamePadSticks = GamePad.GetState(PlayerIndex.One).ThumbSticks;
            direction = new Vector2(gamePadSticks.Left.X, gamePadSticks.Left.Y * -1f);
            //if (gamePad.Down == ButtonState.Pressed)
            //    direction += new Vector2(0, 1);
            //if (gamePad.Up == ButtonState.Pressed)
            //    direction += new Vector2(0, -1);
            //if (gamePad.Left == ButtonState.Pressed)
            //    direction += new Vector2(-1, 0);
            //if (gamePad.Right == ButtonState.Pressed)
            //    direction += new Vector2(1, 0);
            Vector2 positionChanged = direction * speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
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
