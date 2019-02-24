using Microsoft.EntityFrameworkCore;
using DN_DotNET_gram.Models;

namespace DN_DotNET_gram.Data
{
    public class DotNetgramDBContext : DbContext
    {
        /// <summary>
        /// Enables new database
        /// </summary>
        /// <param name="options"></param>
        public DotNetgramDBContext(DbContextOptions<DotNetgramDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// Migration data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Name = "Jason",
                    Details = "Squirrel's With Lightsabers",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 2,
                    Name = "Jason",
                    Details = "Bob Ross",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 3,
                    Name = "Jason",
                    Details = "Deathstar Sunrise",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 4,
                    Name = "Jason",
                    Details = "Volcano",
                    URL = "https://via.placeholder.com/150"
                },
                new Post
                {
                    ID = 5,
                    Name = "Jason",
                    Details = "Glacier",
                    URL = "https://via.placeholder.com/150"
                }
                );
        }

        /// <summary>
        /// Adds Post class to database.
        /// </summary>
        public DbSet<Post> Posts { get; set; }
    }
}
