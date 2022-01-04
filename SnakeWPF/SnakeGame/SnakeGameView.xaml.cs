using System;
using System.Windows;
using System.Windows.Controls;

namespace SnakeWPF.SnakeGame
{
    /// <summary>
    /// Interaction logic for SnakeGameView.xaml
    /// </summary>
    public partial class SnakeGameView : UserControl
    {
        public SnakeGameView()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newGameBoardSize = Math.Min(e.NewSize.Width, e.NewSize.Height);
            GameBoard.Width = newGameBoardSize;
            GameBoard.Height = newGameBoardSize;
        }
    }
}
