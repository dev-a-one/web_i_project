using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<University> Universities { get; set; } = default!;
    public DbSet<Scientist> Scientist { get; set; } = default!;
    public DbSet<Writer> Writers { get; set; } = default!;
    public DbSet<Work> Works { get; set; } = default!;

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

        modelBuilder.Entity<Writer>(e =>
        {
            e.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            e.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Work>(e =>
        {
            e.Property(p => p.Title).IsRequired().HasMaxLength(200);
            e.HasOne(w => w.Writer)
             .WithMany(a => a.Works)
             .HasForeignKey(w => w.WriterId)
             .OnDelete(DeleteBehavior.Cascade);
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

public class Writer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }

    public ICollection<Work> Works { get; set; } = new List<Work>();

    public string FullName => $"{FirstName} {LastName}".Trim();
}

public class Work
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }

    // FK
    public int WriterId { get; set; }
    public Writer Writer { get; set; } = default!;
}
