using Snake.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
