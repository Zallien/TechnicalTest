using Microsoft.EntityFrameworkCore;

namespace MyAPI.Models
{
    public partial class MyAPIDbcontext : DbContext
    {

        public MyAPIDbcontext() { }
        public MyAPIDbcontext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O9CUCLC; Database=TechnicalDatabase; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity => {
                entity
                .ToTable("Employee");
                entity
                .Property(e => e.Row)
                .UseIdentityColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
