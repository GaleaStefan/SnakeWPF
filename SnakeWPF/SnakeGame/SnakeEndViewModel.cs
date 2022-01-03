using Snake.Logic;
using SnakeWPF.Database;
using System;
using System.Collections.ObjectModel;

namespace SnakeWPF.SnakeGame
{
    public class SnakeEndViewModel : BindableBase
    {
        public event Action RestartRequestEvent = delegate { };

        public RelayCommand RestartCommand { get; set; }

        private int score;
        private ObservableCollection<RoundHistory> highscores;
        private string userName;

        public int Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }

        public ObservableCollection<RoundHistory> Highscores
        {
            get => highscores;
            set => SetProperty(ref highscores, value);
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public SnakeEndViewModel()
        {
            Score = 0;
            Highscores = new();
            UserName = "";

            RestartCommand = new(() => RestartRequestEvent.Invoke());
        }
    }
}
