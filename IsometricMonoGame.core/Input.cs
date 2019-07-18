using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsometricMonoGame.core
{
    internal static class Input
    {
        private static readonly Vector2 down = new Vector2(0, 1);
        private static readonly Vector2 up = new Vector2(0, -1);
        private static readonly Vector2 left = new Vector2(-1, 0);
        private static readonly Vector2 right = new Vector2(1, 0);

        internal static Vector2 GetMoveDirection()
        {
            Vector2 direction = new Vector2(0, 0);

            direction = GetKeyboardDirection();

            if (direction.Length() > 0)
                direction.Normalize();

            GamePadThumbSticks gamePadSticks = GamePad.GetState(PlayerIndex.One).ThumbSticks;
            if (gamePadSticks.Left.X != 0 || gamePadSticks.Left.Y != 0)
                direction = GetSticksPosition(gamePadSticks);

            return direction;
        }

        private static Vector2 GetSticksPosition(GamePadThumbSticks gamePadSticks)
        {
            return new Vector2(gamePadSticks.Left.X, gamePadSticks.Left.Y * -1f);
        }

        private static Vector2 GetKeyboardDirection()
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
}
