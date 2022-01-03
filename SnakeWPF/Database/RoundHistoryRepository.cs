using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SnakeWPF.Database
{
    public class RoundHistoryRepository
    {
        private readonly AppDbContext dbContext;

        public RoundHistoryRepository(AppDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<RoundHistory> GetHighScores(int count)
        {
            return dbContext.RoundHistories
                .OrderByDescending(rH => rH.Score)
                .Take(count)
                .Include(rH => rH.User);
        }

        public void InsertRoundHistory(RoundHistory roundHistory)
        {
            dbContext.RoundHistories.Add(roundHistory);
            dbContext.SaveChanges();
        }
    }
}
