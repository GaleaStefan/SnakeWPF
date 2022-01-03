namespace Snake.Logic
{
    public class SnakeHead : BindableBase
    {
        private Point2D position;

        public Point2D Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }

        public SnakeHead()
        {
            position = new();
        }
    }
}
