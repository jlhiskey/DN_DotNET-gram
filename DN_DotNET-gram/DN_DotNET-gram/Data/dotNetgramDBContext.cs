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
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Details = "Squirrel's With Lightsabers",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 2,
                    Details = "Deathstar Sunrise",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 3,
                    Details = "Deathstar Sunrise",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 4,
                    Details = "Volcano",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 5,
                    Details = "Glacier",
                    URL = "https://via.placeholder.com/150"
                }
                );
        }

        public DbSet<Post> Posts { get; set; }
    }
}
