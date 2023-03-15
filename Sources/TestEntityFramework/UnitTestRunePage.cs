using System.Reflection.PortableExecutable;
using Entity_Framework;
using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestRunePage
{
    [Theory]
    [InlineData(1, "Je suis le nom de runePage1", 1)]
    [InlineData(2, "Je suis le nom de runePage2", 2)]

    public void AddCharacteristic_Test(int id, string nom, int nb)
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
        }

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
                
            Assert.Equal(nb, context.RunePageSet.Count());
            Assert.Equal(id, context.RunePageSet.Last().Id);
            Assert.Equal(nom, context.RunePageSet.Last().Name);
                
        }
    }
}