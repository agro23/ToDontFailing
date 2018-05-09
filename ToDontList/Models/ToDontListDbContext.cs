using Microsoft.EntityFrameworkCore;

namespace ToDontList.Models
{
    public class ToDontListDbContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=todontlist;uid=root;pwd=root;");
    }
}