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

        private DispatcherTimer gameTimer;

        #region Properties
        private int _gridSize;

        public int GridSize
        {
            get => _gridSize;
            set => SetProperty(ref _gridSize, value);
        }

        private Snake.Logic.SnakeGame _game;

        public Snake.Logic.SnakeGame Game
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

            gameTimer = new();
            gameTimer.Tick += new(OnGameTick);
            gameTimer.Interval = new(0, 0, 0, 0, 300);
            gameTimer.Start();
        }

        public void StopGame()
        {
            gameTimer.Tick -= OnGameTick;
            gameTimer.Stop();
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
                default:
                    break;
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
