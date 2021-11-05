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
        private static readonly Point2D[] directionOffset = new Point2D[5]
        {
            new(0, 0),
            new(0, -1),
            new(0, 1),
            new(-1, 0),
            new(1, 0)
        };

        private MoveDirection _direction;

        public bool PendingBodyPart { get; set; }

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

        public void Move()
        {
            Point2D nextPos = Head.Position;
            Head.Position += directionOffset[(int)Direction];

            foreach (var bodyPart in Body)
            {
                Point2D currentPos = bodyPart.Position;
                bodyPart.Position = nextPos;
                nextPos = currentPos;
            }

            if(PendingBodyPart)
            {
                Body.Add(new(nextPos));
                PendingBodyPart = false;
            }
        }
    }
}
