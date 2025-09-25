using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<University> Universities { get; set; } = default!;
    public DbSet<Scientist> Scientist { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Basics
        modelBuilder.Entity<Scientist>(e =>
        {
            e.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            e.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        });

        // n:m Scientist <-> University mit explizitem Join-Tabellennamen
        modelBuilder.Entity<Scientist>()
            .HasMany(s => s.AlmaMaters)
            .WithMany() // (uni braucht keine Rücknavigation)
            .UsingEntity<Dictionary<string, object>>(
                "ScientistAlmaMater",
                j => j.HasOne<University>()
                      .WithMany()
                      .HasForeignKey("UniversityId")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Scientist>()
                      .WithMany()
                      .HasForeignKey("ScientistId")
                      .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("ScientistId", "UniversityId");
                    j.ToTable("ScientistAlmaMater");
                });
    }
}

public class University
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public string Ort { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;
    public string Webseite { get; set; } = string.Empty;
    public string Traegerschaft { get; set; } = string.Empty;
}

public class Scientist
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }

    public ICollection<University> AlmaMaters { get; set; } = new List<University>();

    public string FullName => $"{FirstName} {LastName}";
}