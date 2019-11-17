using System;
using MonoGame.core.GameModel;

namespace MonoGame.core
{
    internal class CollisionChecker
    {
        internal Boolean Collides(Hitbox first, Hitbox second)
        {
            Boolean secondLiesCompleteAtLeft = second.Right < first.Left;
            Boolean secondLiesCompleteAtRight = second.Left > first.Right;
            Boolean intersectsOnXAxis = !(secondLiesCompleteAtLeft || secondLiesCompleteAtRight);
            Boolean secondLiesCompleteAtBottom = second.Top < first.Bottom;
            Boolean secondLiesCompleteAtTop = second.Bottom > first.Top;
            Boolean intersectsOnYAxis = !(secondLiesCompleteAtBottom || secondLiesCompleteAtTop);
            return intersectsOnXAxis && intersectsOnYAxis;
        }
    }
}
