using Snake.Logic;
using SnakeWPF.Database;
using SnakeWPF.SnakeGame;

namespace SnakeWPF
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly UserRepository userRepo;
        private readonly RoundHistoryRepository roundHistoryRepo;

        private BindableBase currentVm;
        private SnakeGameViewModel gameViewModel = new();
        private SnakeStartViewModel startViewModel = new();
        private SnakeEndViewModel endViewModel = new();

        private User user;

        public BindableBase CurrentViewModel
        {
            get => currentVm;
            set => SetProperty(ref currentVm, value);
        }

        public MainWindowViewModel(AppDbContext dbContext)
        {
            userRepo = new(dbContext);
            roundHistoryRepo = new(dbContext);

            InitGame();
        }

        private void InitGame()
        {
            gameViewModel = new();
            startViewModel = new();
            endViewModel = new();
            user = null;

            CurrentViewModel = startViewModel;

            startViewModel.StartKeyPressed += OnGameStart;
            gameViewModel.GameEndEvent += OnGameEnd;
            endViewModel.RestartRequestEvent += InitGame;
        }

        private void OnGameStart(int grid, string userName)
        {
            user = userRepo.GetByName(userName) ?? userRepo.Insert(userName);

            gameViewModel.GridSize = grid;
            CurrentViewModel = gameViewModel;
        }

        private void OnGameEnd(int score)
        {
            roundHistoryRepo.InsertRoundHistory(new()
            {
                User = user,
                PlayDateTime = System.DateTime.Now,
                Score = score
            });

            endViewModel.Score = score;
            endViewModel.UserName = user.Name;
            endViewModel.Highscores = new(roundHistoryRepo.GetHighScores(20));
            CurrentViewModel = endViewModel;
        }
    }
}
