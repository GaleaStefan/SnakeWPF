using System.Collections.ObjectModel;

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

        private MoveDirection direction;

        public bool PendingBodyPart { get; set; }

        public MoveDirection Direction
        {
            get => direction;
            set => SetProperty(ref direction, value);
        }

        private SnakeHead head;

        public SnakeHead Head
        {
            get => head;
            set => SetProperty(ref head, value);
        }

        private ObservableCollection<SnakeBodyPart> body;

        public ObservableCollection<SnakeBodyPart> Body
        {
            get => body;
            set => SetProperty(ref body, value);
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

            if (PendingBodyPart)
            {
                Body.Add(new(nextPos));
                PendingBodyPart = false;
            }
        }
    }
}
