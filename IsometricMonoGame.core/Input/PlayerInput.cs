using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsometricMonoGame.core
{
    internal interface IPlayerInput
    {
        Vector2 GetMoveDirection();
    }

    internal abstract class PlayerInput : IPlayerInput
    {
        protected abstract Vector2 GetAxisVectorFromDevice();

        public Vector2 GetMoveDirection()
        {
            Vector2 direction = GetAxisVectorFromDevice();
            if (direction.Length() > 0)
                direction.Normalize();
            return direction;
        }
    }

    internal class KeyboardPlayerInput : PlayerInput
    {
        private static readonly Vector2 down = new Vector2(0, 1);
        private static readonly Vector2 up = new Vector2(0, -1);
        private static readonly Vector2 left = new Vector2(-1, 0);
        private static readonly Vector2 right = new Vector2(1, 0);

        protected override Vector2 GetAxisVectorFromDevice()
        {
            Vector2 direction = new Vector2(0, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                direction += down;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                direction += up;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                direction += left;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                direction += right;

            return direction;
        }
    }

    internal class GamePadPlayerInput : PlayerInput
    {
        protected override Vector2 GetAxisVectorFromDevice()
        {
            Vector2 direction = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            direction.Y *= -1f;
            return direction;
        }
    }
}
