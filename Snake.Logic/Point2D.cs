using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class Point2D : BindableBase
    {
        private int _x;
        private int _y;
        public int X { get => _x; set { SetProperty(ref _x, value); } }
        public int Y { get => _y; set { SetProperty(ref _y, value); } }

        public Point2D(int x, int y) { X = x; Y = y; }

        public static Point2D operator -(Point2D point)
            => new(-point.X, -point.Y);

        public static Point2D operator +(Point2D lhs, Point2D rhs)
            => new(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static Point2D operator -(Point2D lhs, Point2D rhs)
            => lhs + (-rhs);

    }
}
