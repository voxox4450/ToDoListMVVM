using Microsoft.EntityFrameworkCore;
using ToDoListMVVM.Entities;

namespace ToDoListMVVM.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .Property(n => n.ContentText)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Priority)
                .WithMany(n => n.Notes)
                .HasForeignKey(n => n.PriorityId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Status)
                .WithMany(n => n.Notes)
                .HasForeignKey(n => n.StatusId);

            //modelBuilder.Entity<Note>()
            //    .Property(x => x.CreatedOn)
            //    .IsRequired();

            modelBuilder.Entity<Status>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Status>()
                .Property(x => x.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Priority>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Priority>()
                .Property(x => x.Name)
                .HasMaxLength(30);
        }
    }
}