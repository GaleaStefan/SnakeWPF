using Snake.Logic;
using SnakeWPF.SnakeGame;

namespace SnakeWPF
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly SnakeGameViewModel _gameViewModel = new();
        private readonly SnakeStartViewModel _startViewModel = new();
        private readonly SnakeEndViewModel _endViewModel = new();

        private BindableBase _currentVm;

        public BindableBase CurrentViewModel
        {
            get => _currentVm;
            set 
                => SetProperty(ref _currentVm, value);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = _startViewModel;

            _startViewModel.StartKeyPressed += OnGameStart;
            _gameViewModel.GameEndEvent += OnGameEnd;
            _endViewModel.RestartRequestEvent += OnGameRestart;
        }

        private void OnGameStart(int grid)
        {
            _gameViewModel.GridSize = grid;
            CurrentViewModel = _gameViewModel;
        }

        private void OnGameRestart() 
            => CurrentViewModel = _startViewModel;

        private void OnGameEnd(int score) 
            => CurrentViewModel = _endViewModel;
    }
}
