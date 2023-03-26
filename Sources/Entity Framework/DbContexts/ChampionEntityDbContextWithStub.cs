using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;
public class ChampionEntityWithStub : ApplicationDbContext
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var champion1 = new ChampionEntity { Id = 1, Name = "Akali", Icon = "ff", Bio = "gg" };
        var champion2 = new ChampionEntity { Id = 3, Name = "Aatrox", Icon = "gg", Bio = "gg" };
        var champion3 = new ChampionEntity { Id = 4, Name = "Ahri", Icon = "ff", Bio = "gg" };
        var champion4 = new ChampionEntity { Id = 5, Name = "Akshan", Icon = "ff", Bio = "gg" };
        var champion5 = new ChampionEntity { Id = 5, Name = "Bard", Icon = "ff", Bio = "gg" };
        var champion6 = new ChampionEntity { Id = 6, Name = "Alistar", Icon = "ff", Bio = "gg" };

        modelBuilder.Entity<ChampionEntity>().HasData(champion1, champion2, champion3, champion4, champion5, champion6);
        modelBuilder.Entity<SkinEntity>().Property<int>("ChampionId");
        modelBuilder.Entity<SkinEntity>().HasData(
            new { Id = 1, ChampionId = 2, Name = "gg", Description = "truc", Price = (float)11.5 },
            new { Id = 2, ChampionId = 2, Name = "hh", Description = "truc", Price = (float)11.5 },
            new { Id = 3, ChampionId = 2, Name = "ii", Description = "truc", Price = (float)11.5 },
            new { Id = 4, ChampionId = 1, Name = "jj", Description = "truc", Price = (float)11.5 },
            new { Id = 5, ChampionId = 1, Name = "ll", Description = "truc", Price = (float)11.5 }
        );
        modelBuilder.Entity<ChampionEntity>().HasMany(c => c.Skins).WithOne(s => s.ChampionEntity);

        modelBuilder.Entity<SkillEntity>().Property<int>("ChampionId");
        modelBuilder.Entity<SkillEntity>().HasData(
            new { Id = 1, ChampionId = 2, Name = "gg", Description = "truc", Type = "machin" },
            new { Id = 2, ChampionId = 2, Name = "hh", Description = "truc", Type = "machin" },
            new { Id = 3, ChampionId = 2, Name = "ii", Description = "truc", Type = "machin" },
            new { Id = 4, ChampionId = 1, Name = "jj", Description = "truc", Type = "machin" },
            new { Id = 5, ChampionId = 1, Name = "ll", Description = "truc", Type = "machin" }
        );
        modelBuilder.Entity<ChampionEntity>().HasMany(c => c.Skills).WithOne(s => s.ChampionEntity);

        modelBuilder.Entity<CharacteristicsEntity>().Property<ICollection<ChampionEntity>>("ChampionId");
        modelBuilder.Entity<CharacteristicsEntity>().HasData(
            new { Id = 1, ChampionId = 2, Name = "gg", Niveau = 1 },
            new { Id = 2, ChampionId = 2, Name = "hh", Niveau = 2 },
            new { Id = 3, ChampionId = 2, Name = "ii", Niveau = 3 },
            new { Id = 4, ChampionId = 1, Name = "jj", Niveau = 4 },
            new { Id = 5, ChampionId = 1, Name = "ll", Niveau = 5 }
        );
        modelBuilder.Entity<ChampionEntity>().HasMany(c => c.Characteristics).WithMany(s => s.Champions);

        base.SaveChanges();
    }

    //     base.OnModelCreating(modelBuilder);
    //
    //     
    //     var champion1 = new ChampionEntity{Id = 1, Name = "Akali", Icon= "ff", Bio = "gg"};
    //     var champion2 = new ChampionEntity{Id = 3, Name = "Aatrox",Icon = "gg", Bio = "gg"};
    //     var champion3 = new ChampionEntity{Id = 4, Name = "Ahri", Icon= "ff", Bio = "gg"};
    //     var champion4 = new ChampionEntity{Id = 5, Name = "Akshan", Icon= "ff", Bio = "gg"};
    //     var champion5 = new ChampionEntity{Id = 5, Name = "Bard", Icon= "ff", Bio = "gg"};
    //     var champion6 = new ChampionEntity{Id = 6, Name = "Alistar", Icon= "ff", Bio = "gg"};
    //     
    //     modelBuilder.Entity<ChampionEntity>().HasData(champion1, champion2,champion3,champion4,champion5,champion6);
    //     modelBuilder.Entity<SkinEntity>().Property<int>("ChampionId");
    //     modelBuilder.Entity<SkinEntity>().HasData(
    //         new { Id = 1, ChampionId = 2, Name = "gg", Description = "truc", Price = (float)11.5 },
    //         new { Id = 2, ChampionId = 2, Name = "hh", Description = "truc", Price = (float)11.5 },
    //         new { Id = 3, ChampionId = 2, Name = "ii", Description = "truc", Price = (float)11.5 },
    //         new { Id = 4, ChampionId = 1, Name = "jj", Description = "truc", Price = (float)11.5 },
    //         new { Id = 5, ChampionId = 1, Name = "ll", Description = "truc", Price = (float)11.5 }
    //     );
    //     // modelBuilder.Entity<ChampionEntity>().HasMany(c => c.Skins).WithOne(s => s.ChampionEntity);
    //     
    //     base.SaveChanges();
    //}
}
   
