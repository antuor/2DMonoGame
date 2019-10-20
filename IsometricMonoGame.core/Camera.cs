using IsometricMonoGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IsometricMonoGame.core
{
    internal class Camera
    {
        private Dictionary<string, Texture2D> spritesStorage;
        private SpriteBatch spriteBatch;
        private Player player;
        private Vector2 quarterScreenOffset;

        private Vector2 CameraCenter { get => player.Position; }

        internal Camera(Player player, GraphicsDevice graphicsDevice, Dictionary<string, Texture2D> spritesStorage)
        {
            this.spriteBatch = new SpriteBatch(graphicsDevice);
            this.quarterScreenOffset = new Vector2
            {
                X = spriteBatch.GraphicsDevice.Viewport.Width / 4,
                Y = spriteBatch.GraphicsDevice.Viewport.Height / 4
            };
            this.player = player;
            this.spritesStorage = spritesStorage;
        }

        internal void Begin() => spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(2.0f));

        internal void End() => spriteBatch.End();

        internal void Draw(GameObject gameObject)
        {
            Texture2D sprite = spritesStorage[gameObject.SpriteName];

            Vector2 position = gameObject.Position;
            Vector2 worldPosition = new Vector2() { X = position.X - sprite.Width / 2, Y = position.Y - sprite.Height / 2 };
            Vector2 playerCameraOffset = CameraCenter - quarterScreenOffset;
            Vector2 drawPosition = worldPosition - playerCameraOffset;

            spriteBatch.Draw(sprite, drawPosition, Color.White);
        }
    }
}
