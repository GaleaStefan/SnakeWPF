using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class SnakeLogic : BindableBase
    {
        public event Action<int> GameLostEvent;

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

        public SnakeLogic()
        {
            Cherry = new();
            Snake = new();
            Score = 0;
        }
    }
}
