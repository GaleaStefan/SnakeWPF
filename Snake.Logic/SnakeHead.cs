using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class SnakeHead : BindableBase
    {
        private Point2D _pos;

        public Point2D Position
        {
            get { return _pos; }
            set { SetProperty(ref _pos, value); }
        }

        public SnakeHead()
        {
            _pos = new();
        }
    }
}
