using LibraryDemian;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class DB : DbContext
    {
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LibraryDatabase");
        }
    }
}