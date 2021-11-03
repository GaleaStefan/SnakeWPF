using Snake.Logic;
using System;

namespace SnakeWPF.SnakeGame
{
    public class SnakeStartViewModel : BindableBase
    {
        public event Action<int> StartKeyPressed = delegate { };
        public RelayCommand StartCommand { get; private init; }
        public RelayCommand DecreaseGridCommand { get; private init; }
        public RelayCommand IncreaseGridCommand { get; private init; }

        private int _gridSize = 10;

        public int GridSize
        {
            get => _gridSize;
            set
            {
                SetProperty(ref _gridSize, value);
                IncreaseGridCommand.RaiseCanExecuteChanged();
                DecreaseGridCommand.RaiseCanExecuteChanged();
            }
        }


        public SnakeStartViewModel()
        {
            StartCommand = new(OnStart);
            DecreaseGridCommand = new(DecreaseGrid, CanDecreaseGrid);
            IncreaseGridCommand = new(IncreaseGrid, CanIncreaseGrid);
        }

        private void OnStart() 
            => StartKeyPressed.Invoke(GridSize);
        private bool CanDecreaseGrid() 
            => _gridSize > 10;
        private void DecreaseGrid() 
            => GridSize--;
        private bool CanIncreaseGrid() 
            => _gridSize < 35;
        private void IncreaseGrid() 
            => GridSize++;
    }
}
