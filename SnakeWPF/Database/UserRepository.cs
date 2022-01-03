using System.Linq;

namespace SnakeWPF.Database
{
    public class UserRepository
    {
        private readonly AppDbContext

            context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User? GetByName(string name)
            => context.Users.FirstOrDefault(user => user.Name == name);

        public User Insert(string name)
        {
            var inserted = context.Users.Add(new() { Name = name, JoinDate = System.DateTime.Now }).Entity;
            context.SaveChanges();

            return inserted;
        }
    }
}
