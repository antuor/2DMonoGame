using MonoGame.Core.GameModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace MonoGame.Core
{
    internal class Camera
    {
        private Dictionary<string, Texture2D> spritesStorage;
        private SpriteBatch spriteBatch;
        private Player player;
        private Vector2 quarterScreenOffset;
        private Vector2 cameraCenter;
        private Vector2 playerFrame;

        internal Camera(Player player, GraphicsDevice graphicsDevice, Dictionary<string, Texture2D> spritesStorage,
            Single playerFramePercentWidth, Single playerFramePercentHeight)
        { 
            this.spriteBatch = new SpriteBatch(graphicsDevice);
            Viewport viewport = spriteBatch.GraphicsDevice.Viewport;
            this.quarterScreenOffset = new Vector2 { X = viewport.Width / 4, Y = viewport.Height / 4 };
            this.player = player;
            this.cameraCenter = player.Position;
            this.spritesStorage = spritesStorage;
            this.playerFrame = new Vector2()
            {
                X = quarterScreenOffset.X * playerFramePercentWidth / 100,
                Y = quarterScreenOffset.Y * playerFramePercentHeight / 100
            };
        }
 
        internal void Begin() => spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(2.0f));
        internal void End() => spriteBatch.End();

        internal void Draw(GameObject gameObject)
        {
            Texture2D sprite = spritesStorage[gameObject.SpriteName];

            Vector2 position = gameObject.Position;
            Vector2 worldPosition = new Vector2() { X = position.X - sprite.Width / 2, Y = position.Y - sprite.Height / 2 };


            Vector2 drawPosition = GetDrawPosition(worldPosition);
            spriteBatch.Draw(sprite, drawPosition, Color.White);
        }

        internal Vector2 GetDrawPosition(Vector2 worldPosition)
        {
            RecalculateCameraCenter();
            Vector2 CameraOffset = cameraCenter - quarterScreenOffset;
            Vector2 drawPosition = worldPosition - CameraOffset;
            return drawPosition;
        }

        internal void RecalculateCameraCenter()
        {
            Vector2 currentDifference = player.Position - cameraCenter;
            if (currentDifference.X > playerFrame.X)
                cameraCenter.X += currentDifference.X - playerFrame.X;
            if (currentDifference.X < -playerFrame.X)
                cameraCenter.X += currentDifference.X + playerFrame.X;
            if (currentDifference.Y > playerFrame.Y)
                cameraCenter.Y += currentDifference.Y - playerFrame.Y;
            if (currentDifference.Y < -playerFrame.Y)
                cameraCenter.Y += currentDifference.Y + playerFrame.Y;
        }
    }
}
