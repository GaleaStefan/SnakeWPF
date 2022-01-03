using Snake.Logic;
using SnakeWPF.Database;
using SnakeWPF.SnakeGame;

namespace SnakeWPF
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly SnakeGameViewModel gameViewModel = new();
        private readonly SnakeStartViewModel startViewModel = new();
        private readonly SnakeEndViewModel endViewModel = new();
        private readonly UserRepository userRepo;
        private User user = null;

        private BindableBase currentVm;

        public BindableBase CurrentViewModel
        {
            get => currentVm;
            set => SetProperty(ref currentVm, value);
        }

        public MainWindowViewModel(AppDbContext dbContext)
        {
            userRepo = new(dbContext);
            CurrentViewModel = startViewModel;

            startViewModel.StartKeyPressed += OnGameStart;
            gameViewModel.GameEndEvent += OnGameEnd;
            endViewModel.RestartRequestEvent += OnGameRestart;
        }

        private void OnGameStart(int grid, string userName)
        {
            user = userRepo.GetByName(userName);

            if (user is null)
                user = userRepo.Insert(userName);

            gameViewModel.GridSize = grid;
            CurrentViewModel = gameViewModel;
        }

        private void OnGameRestart()
            => CurrentViewModel = startViewModel;

        private void OnGameEnd(int score)
            => CurrentViewModel = endViewModel;
    }
}
