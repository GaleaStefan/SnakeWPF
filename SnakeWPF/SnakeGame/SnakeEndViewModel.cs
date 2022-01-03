using Snake.Logic;
using System;

namespace SnakeWPF.SnakeGame
{
    public class SnakeEndViewModel : BindableBase
    {
        public event Action RestartRequestEvent = delegate { };

        public SnakeEndViewModel()
        {

        }
    }
}
