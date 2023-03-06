using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Models
{
    internal class MagazineContext:DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsDetails> NewsDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FUG26SB;Database=Magazine;Trusted_Connection=True; TrustServerCertificate=true;");
        }


    }
}
