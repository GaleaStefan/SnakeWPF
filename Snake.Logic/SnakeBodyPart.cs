using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class SnakeBodyPart : BindableBase
    {
        private Point2D _pos;

        public Point2D Position
        {
            get { return _pos; }
            set { SetProperty(ref _pos, value); }
        }

        public SnakeBodyPart()
        {
            Position = new();
        }

        public SnakeBodyPart(Point2D postion)
        {
            Position = postion;
        }
    }
}
