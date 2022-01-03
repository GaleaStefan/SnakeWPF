using System;

namespace Snake.Logic
{
    public class Point2D : BindableBase
    {
        private int x;
        private int y;
        public int X { get => x; set => SetProperty(ref x, value); }
        public int Y { get => y; set => SetProperty(ref y, value); }

        public Point2D() { X = 0; Y = 0; }
        public Point2D(int x, int y) { X = x; Y = y; }

        public static Point2D operator -(Point2D point)
            => new(-point.X, -point.Y);

        public static Point2D operator +(Point2D lhs, Point2D rhs)
            => new(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static Point2D operator -(Point2D lhs, Point2D rhs)
            => lhs + (-rhs);


        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point2D p = (Point2D)obj;
                return (X == p.X) && (Y == p.Y);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
