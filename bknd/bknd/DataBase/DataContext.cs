using bknd.Users;
using Microsoft.EntityFrameworkCore;

namespace bknd.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
                //crearea tabelului users
        public DbSet<User> users { get; set; }
    }
}