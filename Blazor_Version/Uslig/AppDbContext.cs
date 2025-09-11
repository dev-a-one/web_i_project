using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<University> Universities { get; set; } = default!;
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