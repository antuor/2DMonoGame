using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsometricMonoGame.core
{
    internal static class Input
    {
        internal static Vector2 GetMoveDirection()
        {
            Vector2 direction = new Vector2(0, 0);

            direction = GetKeyboardDirection();

            if (direction.Length() > 0)
                direction.Normalize();

            GamePadThumbSticks gamePadSticks = GamePad.GetState(PlayerIndex.One).ThumbSticks;
            if (gamePadSticks.Left.X != 0 || gamePadSticks.Left.Y != 0)
                direction = new Vector2(gamePadSticks.Left.X, gamePadSticks.Left.Y * -1f);

            return direction;
        }

        private static Vector2 GetKeyboardDirection()
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

    }
}
