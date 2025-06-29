using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using webApi.Model;

namespace webApi.Infrastructure
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {            
            
        }

        public DbSet<UsersModel> usersSample { get; set; }
    }
}
