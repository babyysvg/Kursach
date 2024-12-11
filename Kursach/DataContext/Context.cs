using Kursach;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataBases.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Vhod> Vhods { get; set; }
        public DbSet<Vyhod> Vyhods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vhod>()
                .HasOne(v => v.vyhod)
                .WithOne(vh => vh.vhod)
                .HasForeignKey<Vyhod>(vh => vh.VhodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public Context() : base(new DbContextOptionsBuilder<Context>()
            .UseSqlServer("Server=.;Database=BD_Kurs;Integrated Security=true; TrustServerCertificate=True")
            .Options)
        {
        }
    }
}
