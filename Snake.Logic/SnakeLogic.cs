using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class SnakeLogic : BindableBase
    {
        public event Action<int> GameLostEvent = delegate { };

        private int _score;

        public int Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }

        private Cherry _cherry;

        public Cherry Cherry
        {
            get { return _cherry; }
            set { SetProperty(ref _cherry, value); }
        }

        private Snake _snake;

        public Snake Snake
        {
            get { return _snake; }
            set { SetProperty(ref _snake, value); }
        }

        public int GridSize { get; set; }

        private bool _gameRunning;

        public bool GameIsRunning
        {
            get => _gameRunning;
            set => SetProperty(ref _gameRunning, value);
        }

        public SnakeLogic()
        {
            Cherry = new();
            Snake = new();
            Score = 0;
        }

        public void Tick()
        {
            if (Snake.Direction == MoveDirection.NONE)
                return;

            if (SnakeHeadOnCherry())
            {
                Score++;
                RespawnCherry();
                Snake.PendingBodyPart = true;
            }

            Snake.Move();

            if (SnakeInCollisionWithItself() || SnakeOutOfBounds())
            {
                GameIsRunning = false;
                GameLostEvent.Invoke(Score);
                return;
            }
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
            return Snake.Head.Position.X < 0 || Snake.Head.Position.X > GridSize ||
                Snake.Head.Position.Y < 0 || Snake.Head.Position.Y > GridSize;
        }

        private bool SnakeInCollisionWithItself()
            => Snake.Body.Any(part => part.Position.Equals(Snake.Head.Position));
    }
}
