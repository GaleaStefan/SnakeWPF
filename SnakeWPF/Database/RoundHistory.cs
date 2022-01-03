using System;

namespace SnakeWPF.Database
{
    public class RoundHistory
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Score { get; set; }
        public DateTime PlayDateTime { get; set; }
    }
}
