using System;
using System.Linq;

namespace Snake.Logic
{
    public class SnakeGame : BindableBase
    {
        public event Action<int> GameLostEvent = delegate { };

        private int score;

        public int Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }

        private Cherry cherry;

        public Cherry Cherry
        {
            get => cherry;
            set => SetProperty(ref cherry, value);
        }

        private Snake snake;

        public Snake Snake
        {
            get => snake;
            set => SetProperty(ref snake, value);
        }

        public int GridSize { get; set; }

        private bool isRunning;

        public bool GameIsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }

        public SnakeGame()
        {
            Cherry = new();
            Snake = new();
            Score = 0;
        }

        public void Tick()
        {
            if (Snake.Direction == MoveDirection.NONE || GameIsRunning == false)
                return;

            if (SnakeHeadOnCherry())
            {
                Score++;
                RespawnCherry();
                Snake.PendingBodyPart = true;
            }

            if (SnakeInCollisionWithItself() || SnakeOutOfBounds())
            {
                GameIsRunning = false;
                GameLostEvent.Invoke(Score);
                return;
            }

            Snake.Move();
        }

        public void Initialize()
        {

            Cherry.Position = PlaceRandom();

            do
            {
                Snake.Head.Position = PlaceRandom();

            } while (Cherry.Position.Equals(Snake.Head.Position));

            GameIsRunning = true;
        }

        private Point2D PlaceRandom()
        {
            Point2D position = new();
            Random random = new();
            position.X = random.Next(0, GridSize);
            position.Y = random.Next(0, GridSize);

            return position;
        }

        private bool IsInCollisionWithSnake(Point2D position)
        {
            if (position.Equals(Snake.Head.Position))
                return true;

            return Snake.Body.Any(part => part.Position.Equals(position));
        }

        private bool SnakeHeadOnCherry()
            => Cherry.Position.Equals(Snake.Head.Position);

        private void RespawnCherry()
        {
            Point2D newPos;

            do
            {
                newPos = PlaceRandom();
            } while (IsInCollisionWithSnake(newPos));

            Cherry.Position = newPos;
        }

        private bool SnakeOutOfBounds()
        {
            return Snake.Head.Position.X < 0 || Snake.Head.Position.X >= GridSize ||
                Snake.Head.Position.Y < 0 || Snake.Head.Position.Y >= GridSize;
        }

        private bool SnakeInCollisionWithItself()
            => Snake.Body.Any(part => part.Position.Equals(Snake.Head.Position));
    }
}
