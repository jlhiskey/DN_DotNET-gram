using Microsoft.EntityFrameworkCore;
using DN_DotNET_gram.Models;

namespace DN_DotNET_gram.Data
{
    public class DotNetgramDBContext : DbContext
    {
        public DotNetgramDBContext(DbContextOptions<DotNetgramDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        //public DbSet<{MODEL HERE> Modelhere { get; set; }
    }
}
