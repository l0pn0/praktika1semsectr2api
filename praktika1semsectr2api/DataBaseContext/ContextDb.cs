using Microsoft.EntityFrameworkCore;
using praktika1semsectr2api.Model;

namespace praktika1semsectr2api.DataBaseContext
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<RegisterModel> Users { get; set; }
    }
}
