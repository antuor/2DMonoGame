using System;
using IsometricMonoGame.core;
using IsometricMonoGame.core.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsometricMonoGame.Core
{
    internal class Player : GameObject
    {
        
        private Int32 speed = 100;

        internal Player(Texture2D sprite) : base(sprite) { }

        internal void Move(GameTime gameTime)
        {
            IPlayerInput playerInput = PlayerInputFactory.Create();
            Vector2 direction = playerInput.GetMoveDirection();
            Vector2 positionChanged = direction * speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            Position += positionChanged;
        }
    }
}
