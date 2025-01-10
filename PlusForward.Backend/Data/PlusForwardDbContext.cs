using Microsoft.EntityFrameworkCore;
using PlusForward.Backend.Data.Models;

namespace PlusForward.Backend.Data;

public class PlusForwardDbContext : DbContext
{
    private readonly IConfiguration _config;

    public DbSet<ServerData> ServersData { get; set; }

    public PlusForwardDbContext(DbContextOptions<PlusForwardDbContext> options, IConfiguration config): base(options)
    {
        _config = config;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Guid.NewGuid().ToString("N")
        modelBuilder.Entity<ServerData>()
            .Property(s => s.ServerId)
            .HasMaxLength(36)
            .IsRequired();
        
        modelBuilder.Entity<ServerData>()
            .Property(s => s.IpAddress)
            .HasMaxLength(15)
            .IsRequired();
        
        modelBuilder.Entity<ServerData>()
            .Property(s => s.ServerName)
            .HasMaxLength(25)
            .IsRequired();
        
        modelBuilder.Entity<ServerData>()
            .Property(s => s.MapName)
            .HasMaxLength(25)
            .IsRequired();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? connectionString = _config.GetConnectionString("Default");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}