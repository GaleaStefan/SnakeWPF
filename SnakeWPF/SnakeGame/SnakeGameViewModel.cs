using Snake.Logic;
using System;
using System.Windows.Threading;

namespace SnakeWPF.SnakeGame
{
    public class SnakeGameViewModel : BindableBase
    {
        #region Events
        public event Action<int> GameEndEvent = delegate { };
        #endregion

        #region Commands
        public RelayCommand<MoveDirection> DirectionChangeCommand { get; set; }
        public RelayCommand ControlLoadedCommand { get; set; }
        #endregion

        private DispatcherTimer _gameTimer;

        #region Properties
        private int _gridSize;

        public int GridSize
        {
            get { return _gridSize; }
            set { SetProperty(ref _gridSize, value); }
        }

        private SnakeLogic _game;

        public SnakeLogic Game
        {
            get => _game;
            set => SetProperty(ref _game, value);
        }

        #endregion

        public SnakeGameViewModel()
        {
            DirectionChangeCommand = new(OnDirectionTryChange);
            ControlLoadedCommand = new(StartGame);
        }

        private void StartGame()
        {
            Game = new();
            Game.GameLostEvent += OnGameLost;
            Game.GridSize = GridSize;
            Game.Initialize();

            _gameTimer = new();
            _gameTimer.Tick += new(OnGameTick);
            _gameTimer.Interval = new(0, 0, 0, 0, 300);
            _gameTimer.Start();
        }

        public void StopGame()
        {
            _gameTimer.Tick -= OnGameTick;
            _gameTimer.Stop();
        }

        private void OnGameTick(object sender, EventArgs args)
        {
            Game.Tick();
        }

        private void OnDirectionTryChange(MoveDirection direction)
        {
            switch (Game.Snake.Direction)
            {
                case MoveDirection.UP when direction == MoveDirection.DOWN:
                case MoveDirection.DOWN when direction == MoveDirection.UP:
                case MoveDirection.LEFT when direction == MoveDirection.RIGHT:
                case MoveDirection.RIGHT when direction == MoveDirection.LEFT:
                    return;
            }

            Game.Snake.Direction = direction;
        }

        private void OnGameLost(int score)
        {
            StopGame();
            GameEndEvent.Invoke(score);
        }
    }
}
