using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;

public class RunePageEntityDBContextWithStub : ApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var runePage1 = new RunePageEntity{Id = 1, Name = "runePage1"};
        var runePage2 = new RunePageEntity{Id = 2, Name = "runePage2"};
        var runePage3 = new RunePageEntity{Id = 3, Name = "runePage3"};
        var runePage4 = new RunePageEntity{Id = 4, Name = "runePage4"};
        var runePage5 = new RunePageEntity{Id = 5, Name = "runePage5"};
        var runePage6 = new RunePageEntity{Id = 6, Name = "runePage6"};
        
        modelBuilder.Entity<RunePageEntity>().HasData(runePage1, runePage2, runePage3, runePage4, runePage5, runePage6);
        modelBuilder.Entity<RuneEntity>().Property<ICollection<RunePageEntity>>("ChampionId");
        modelBuilder.Entity<RuneEntity>().HasData(
            new { Id = 1, ChampionId = 2, Name = "gg", Description = "truc", Family = "chose", Icon = "bidule", Image = "chouette", Category = "machin"},
            new { Id = 2, ChampionId = 2, Name = "hh", Description = "truc", Family = "chose", Icon = "bidule", Image = "chouette", Category = "machin" },
            new { Id = 3, ChampionId = 2, Name = "ii", Description = "truc", Family = "chose", Icon = "bidule", Image = "chouette", Category = "machin" },
            new { Id = 4, ChampionId = 1, Name = "jj", Description = "truc", Family = "chose", Icon = "bidule", Image = "chouette", Category = "machin" },
            new { Id = 5, ChampionId = 1, Name = "ll", Description = "truc", Family = "chose", Icon = "bidule", Image = "chouette", Category = "machin" }
        );
        modelBuilder.Entity<RunePageEntity>().HasMany(c => c.Runes).WithMany(s => s.RunePages);
        
        base.SaveChanges();
    }
}