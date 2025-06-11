using Figura.SpeedwayNetwork.Model.DAO;
using Microsoft.EntityFrameworkCore;

namespace Figura.SpeedwayNetwork.Model;

public partial class SpeedwayNetworkContext : DbContext
{
    private string? _connectionString;
    public SpeedwayNetworkContext(DbContextOptions<SpeedwayNetworkContext> options) : base(options)
    {
        
    }
    public SpeedwayNetworkContext()
    {
    }

    public SpeedwayNetworkContext(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<FirstName> FirstNames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Polish_100_CI_AI_KS_WS_SC_UTF8");

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07E821ACAE");

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FlagPictureUrl).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<FirstName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FirstNam__3214EC0726ABF20A");

            entity.ToTable("FirstName");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
