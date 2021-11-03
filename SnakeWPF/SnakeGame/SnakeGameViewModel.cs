using Snake.Logic;
using System;
using System.Windows.Threading;

namespace SnakeWPF.SnakeGame
{
    public class SnakeGameViewModel : BindableBase
    {
        #region Events
        public event Action<int> GameLostEvent = delegate { };
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
            get { return _game; }
            set { SetProperty(ref _game, value); }
        }

        #endregion

        public SnakeGameViewModel()
        {
            DirectionChangeCommand = new(OnDirectionChange);
            ControlLoadedCommand = new(StartGame);
        }

        private void StartGame()
        {
            Game = new();
            _gameTimer = new();
            _gameTimer.Tick += new(OnGameTick);
            _gameTimer.Interval = new(0, 0, 5);
            _gameTimer.Start();
        }

        public void StopGame()
        {
            _gameTimer.Stop();
        }

        private void OnGameTick(object sender, EventArgs args)
        {
            
        }

        private void OnDirectionChange(MoveDirection direction)
        {

        }
    }
}
