using Snake.Logic;
using System;
using System.Linq;

namespace SnakeWPF.SnakeGame
{
    public class SnakeStartViewModel : BindableBase
    {
        public event Action<int, string> StartKeyPressed = delegate { };

        public RelayCommand StartCommand { get; private init; }
        public RelayCommand DecreaseGridCommand { get; private init; }
        public RelayCommand IncreaseGridCommand { get; private init; }

        private string userName;
        private int gridSize = 10;

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                SetProperty(ref userName, value);
                StartCommand.RaiseCanExecuteChanged();
            }
        }

        public int GridSize
        {
            get => gridSize;
            set
            {
                SetProperty(ref gridSize, value);
                IncreaseGridCommand.RaiseCanExecuteChanged();
                DecreaseGridCommand.RaiseCanExecuteChanged();
            }
        }

        public SnakeStartViewModel()
        {
            StartCommand = new(OnStart, CanStart);
            DecreaseGridCommand = new(DecreaseGrid, CanDecreaseGrid);
            IncreaseGridCommand = new(IncreaseGrid, CanIncreaseGrid);
        }

        private void OnStart()
        {
            StartKeyPressed.Invoke(GridSize, UserName);
        }

        private bool CanStart()
            => UserName is not null && UserName.Length > 3 && UserName.All(c => char.IsLetterOrDigit(c));

        private bool CanDecreaseGrid()
            => gridSize > 10;
        private void DecreaseGrid()
            => GridSize--;
        private bool CanIncreaseGrid()
            => gridSize < 35;
        private void IncreaseGrid()
            => GridSize++;
    }
}
