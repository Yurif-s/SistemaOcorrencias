using Microsoft.EntityFrameworkCore;
using SistemaOcorrencias.Domain.Entities;

namespace SistemaOcorrencias.Infrastructure.DataAccess;

internal class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Occurrence> Occurrences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<Student>()
        .HasOne(s => s.Classroom)
        .WithMany(c => c.Students)
        .HasForeignKey(s => s.ClassroomId)
        .OnDelete(DeleteBehavior.Restrict);        

        modelBuilder.Entity<Occurrence>()
            .HasOne(o => o.Student)
            .WithMany(s => s.Occurrences)
            .HasForeignKey(o => o.StudentId)
            .OnDelete(DeleteBehavior.Cascade);         

        modelBuilder.Entity<Occurrence>()
            .HasOne(o => o.Classroom)
            .WithMany(c => c.Occurrences)
            .HasForeignKey(o => o.ClassroomId)
            .OnDelete(DeleteBehavior.Restrict);        


        modelBuilder.Entity<Occurrence>()
            .HasOne(o => o.RegisteredBy)
            .WithMany()
            .HasForeignKey(o => o.RegisteredById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
