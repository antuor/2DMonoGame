using System;
using IsometricMonoGame.core;
using IsometricMonoGame.core.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsometricMonoGame.Core
{
    internal sealed class Player : GameObject
    {
        private const string spriteName = "player";
        private Int32 speed = 100;

        internal Player(GameCore game) : base(game, spriteName, new Vector2(0, 0)) { }

        internal void Move(GameTime gameTime)
        {
            IPlayerInput playerInput = PlayerInputFactory.Create();
            Vector2 direction = playerInput.GetMoveDirection();
            Vector2 positionChanged = direction * speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            Position += positionChanged;
        }
    }
}
