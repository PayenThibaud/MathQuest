using Microsoft.EntityFrameworkCore;
using MathQuestCore.Model;
using MathQuestCore.Data;

namespace MathQuestAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Lecon> Lecons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>().HasData(InitialModel.Utilisateurs);
            modelBuilder.Entity<Lecon>().HasData(InitialModel.Lecons);

            modelBuilder.Entity<LeconLu>()
                .HasKey(ll => new { ll.UtilisateurId, ll.LeconId });

            modelBuilder.Entity<LeconLu>()
                .HasOne(ll => ll.Utilisateur)
                .WithMany(u => u.LeconLus)
                .HasForeignKey(ll => ll.UtilisateurId);

            modelBuilder.Entity<LeconLu>()
                .HasOne(ll => ll.Lecon)
                .WithMany(l => l.LeconLus)
                .HasForeignKey(ll => ll.LeconId);
        }

    }
}
