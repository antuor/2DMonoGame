using System;
using MonoGame.Core.Input;
using Microsoft.Xna.Framework;

namespace MonoGame.Core.GameModel
{
    internal sealed class Player : GameObject
    {
        internal const string CommonSpriteNameRight = "playerRight";
        internal const string CommonSpriteNameLeft = "playerLeft";
        internal IPlayerInput playerInput = PlayerInputFactory.Create();
        private Int32 speed = 100;

        internal Player() : base(CommonSpriteNameRight, position: new Vector2(0, 0)) { }

        internal void Move(GameTime gameTime)
        {
            Vector2 direction = playerInput.GetMoveDirection();
            Vector2 positionChanged = direction * speed * (Single)gameTime.ElapsedGameTime.TotalSeconds;
            Position += positionChanged;
            ChooseSpriteFromDirection(direction);
        }

        internal void ChooseSpriteFromDirection(Vector2 direction)
        {
            if (direction.X < 0)
                this.SpriteName = Player.CommonSpriteNameLeft;
            else if (direction.X > 0)
                this.SpriteName = Player.CommonSpriteNameRight;
        }
    }
}
