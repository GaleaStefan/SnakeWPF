namespace Snake.Logic
{
    public class SnakeBodyPart : BindableBase
    {
        private Point2D position;

        public Point2D Position
        {
            get => position;
            set => SetProperty(ref position, value);
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
