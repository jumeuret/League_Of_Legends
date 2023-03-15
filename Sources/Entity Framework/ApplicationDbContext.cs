using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;

public class ApplicationDbContext : DbContext
{
    public DbSet<ChampionEntity> ChampionSet { get; set; }
    public DbSet<SkillEntity> SkillSet{ get; set; }
    public DbSet<SkinEntity> SkinSet { get; set;  }
    public DbSet<CharacteristicsEntity> CharacteristicSet { get; set; }
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
        // modelBuilder.Entity<ChampionEntity>().ToTable("Champions");
        //
        // modelBuilder.Entity<ChampionEntity>().HasKey(c => c.Id);
        //
        // modelBuilder.Entity<ChampionEntity>().Property(c => c.Id).ValueGeneratedOnAdd();
        //
        // modelBuilder.Entity<ChampionEntity>().Property(c => c.Name).IsRequired();
        //
        // modelBuilder.Entity<ChampionEntity>().Property(c => c.Icon);
        //
        // modelBuilder.Entity<ChampionEntity>().Property(c => c.Bio);
        //
        // base.OnModelCreating(modelBuilder);
        
        base.OnModelCreating(modelBuilder);

        var champion1 = new ChampionEntity{Id = 1, Name = "Akali", Icon= "ff", Bio = "gg"};
        var champion2 = new ChampionEntity{Id = 3, Name = "Aatrox",Icon = "gg", Bio = "gg"};
        var champion3 = new ChampionEntity{Id = 4, Name = "Ahri", Icon= "ff", Bio = "gg"};
        var champion4 = new ChampionEntity{Id = 5, Name = "Akshan", Icon= "ff", Bio = "gg"};
        var champion5 = new ChampionEntity{Id = 5, Name = "Bard", Icon= "ff", Bio = "gg"};
        var champion6 = new ChampionEntity{Id = 6, Name = "Alistar", Icon= "ff", Bio = "gg"};
        
        modelBuilder.Entity<ChampionEntity>().HasData(champion1, champion2,champion3,champion4,champion5,champion6);
        modelBuilder.Entity<SkinEntity>().Property<int>("ChampionId");
        modelBuilder.Entity<SkinEntity>().HasData(
            new { Id = 1, ChampionId = 2, Name = "gg", Description = "truc", Price = (float)11.5 },
            new { Id = 2, ChampionId = 2, Name = "hh", Description = "truc", Price = (float)11.5 },
            new { Id = 3, ChampionId = 2, Name = "ii", Description = "truc", Price = (float)11.5 },
            new { Id = 4, ChampionId = 1, Name = "jj", Description = "truc", Price = (float)11.5 },
            new { Id = 5, ChampionId = 1, Name = "ll", Description = "truc", Price = (float)11.5 }
        );
        // modelBuilder.Entity<ChampionEntity>().HasMany(c => c.Skins).WithOne(s => s.ChampionEntity);
        
        base.SaveChanges();
    }

}