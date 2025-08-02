using System.Drawing;

namespace CloneHeroBot
{
    public class PointEventArgs(Point point) : EventArgs
    {
        public Point Point { get; } = point;
    }
}
