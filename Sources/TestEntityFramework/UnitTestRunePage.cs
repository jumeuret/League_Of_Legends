using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestRunePage
{
    [Theory]
    [InlineData(1, "Je suis le nom de runePage1")]
    [InlineData(2, "Je suis le nom de runePage2")]

    public void AddRunePage_Test(int id, string nom)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddRunePageDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            RunePageEntity runePage = new RunePageEntity()
            {
                Id = id,
                Name = nom,
            };
                    
            context.RunePageSet.Add(runePage);

            context.SaveChanges();
                
            Assert.Equal(1, context.RunePageSet.Count());
            Assert.Equal(id, context.RunePageSet.Last().Id);
            Assert.Equal(nom, context.RunePageSet.Last().Name);
                
            context.RunePageSet.Remove(runePage);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData(1, "Je suis le nom de runePage1", "Je suis le nom de runePage2")]
    [InlineData(3, "Je suis le nom de runePage3", "Je suis le nom de runePage4")]

    public void ModifyRunePage_Test(int id, string old_nom, string new_nom)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ModifyRunePageDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            RunePageEntity runePage = new RunePageEntity()
            {
                Id = id,
                Name = old_nom,
            };
                    
            context.RunePageSet.Add(runePage);

            context.SaveChanges();

            context.RunePageSet.Last().Name = new_nom;
            
            context.RunePageSet.Update(runePage);

            context.SaveChanges();
                
            Assert.Equal(1, context.RunePageSet.Count());
            Assert.NotEqual(old_nom, context.RunePageSet.Last().Name);
            Assert.Equal(new_nom, context.RunePageSet.Last().Name);
                
            context.RunePageSet.Remove(runePage);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData(1, "Je suis le nom de runePage1")]
    [InlineData(2, "Je suis le nom de runePage2")]

    public void DeleteRunePage_Test(int id, string nom)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "DeleteRunePageDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            RunePageEntity runePage = new RunePageEntity()
            {
                Id = id,
                Name = nom,
            };
                    
            context.RunePageSet.Add(runePage);

            context.SaveChanges();
                
            Assert.Equal(1, context.RunePageSet.Count());
            Assert.Equal(id, context.RunePageSet.Last().Id);
            Assert.Equal(nom, context.RunePageSet.Last().Name);
                
            context.RunePageSet.Remove(runePage);

            context.SaveChanges();
        }
    }
}