using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class Cherry : BindableBase
    {
        private Point2D _pos;

        public Point2D Position
        {
            get { return _pos; }
            set { SetProperty(ref _pos, value); }
        }

        public Cherry() { _pos = new(); }
    }
}
