using bknd.Users;
using bknd.Workshops;
using Microsoft.EntityFrameworkCore;


namespace bknd.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
                
        public DbSet<User> users { get; set; }
        public DbSet<Team.Team> teams { get; set; }
        public DbSet<UserProfile.UserProfile> userprofiles { get; set; }
        public DbSet<Workshop> workshops { get; set; }
    }
}