namespace Snake.Logic
{
    public class Cherry : BindableBase
    {
        private Point2D position;

        public Point2D Position
        {
            get { return position; }
            set { SetProperty(ref position, value); }
        }

        public Cherry() { position = new(); }
    }
}
