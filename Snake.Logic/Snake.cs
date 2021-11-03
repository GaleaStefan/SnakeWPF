using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class Snake : BindableBase
    {
        private MoveDirection _direction;

        public MoveDirection Direction
        {
            get { return _direction; }
            set { SetProperty(ref _direction, value); }
        }


        private SnakeHead _head;

        public SnakeHead Head
        {
            get { return _head; }
            set { SetProperty(ref _head, value); }
        }

        private ObservableCollection<SnakeBodyPart> _body;

        public ObservableCollection<SnakeBodyPart> Body
        {
            get { return _body; }
            set { SetProperty(ref _body, value); }
        }

        public Snake()
        {
            Direction = MoveDirection.NONE;
            Head = new();
            Body = new();
        }

    }
}
