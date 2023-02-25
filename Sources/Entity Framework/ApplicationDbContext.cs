using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;

public class ApplicationDbContext : DbContext
{
    public DbSet<ChampionEntity> ChampionSet { get; set; }
    public DbSet<SkillEntity> SkillSet{ get; set; }
    public DbSet<SkinEntity> SkinSet { get; set;  }
    public DbSet<CharasteristicsEntity> CharacteristicSet { get; set; }
    public DbSet<RuneEntity> RuneSet { get; set; }
    public DbSet<RunePageEntity> RunePageSet { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=LeagueOfLegends.db");
        }
    }
    
    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChampionEntity>().ToTable("Champions");

        modelBuilder.Entity<ChampionEntity>().HasKey(c => c.Id);

        modelBuilder.Entity<ChampionEntity>().Property(c => c.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<ChampionEntity>().Property(c => c.Name).IsRequired();

        modelBuilder.Entity<ChampionEntity>().Property(c => c.Icon);

        modelBuilder.Entity<ChampionEntity>().Property(c => c.Bio);

        base.OnModelCreating(modelBuilder);
    }

}