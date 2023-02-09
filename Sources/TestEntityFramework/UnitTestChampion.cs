using System.Linq;
using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Xunit;

namespace TestEntityFramework
{
    public class UnitTest1
    {
        
       
        [Fact]
        public void AddChampion_Test()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion1 = new ChampionEntity
                {
                    Name = "Test1",
                    Bio = "Je suis la bio du test1",
                    Icon = "Je suis l'icone du test1",
                };
                ChampionEntity champion2 = new ChampionEntity
                {
                        Name = "Test2",
                        Bio = "Je suis la bio du test2",
                        Icon = "Je suis l'icon du test2",
                };

                context.ChampionSet.Add(champion1);
                context.ChampionSet.Add(champion2);
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(2, context.ChampionSet.Count());
                Assert.Equal("Test1", context.ChampionSet.First().Name);
                Assert.Equal("Je suis la bio du test1", context.ChampionSet.First().Bio);
                Assert.Equal("Je suis l'icone du test1", context.ChampionSet.First().Icon);
            }
        }

        [Fact]
        public void ModifyChampion_Test()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion1 = new ChampionEntity
                {
                    Name = "Test1",
                    Bio = "Je suis la bio du test1",
                    Icon = "Je suis l'icone du test1",
                };
                ChampionEntity champion2 = new ChampionEntity
                {
                    Name = "Test2",
                    Bio = "Je suis la bio du test2",
                    Icon = "Je suis l'icon du test2",
                };

                context.ChampionSet.Add(champion1);
                context.ChampionSet.Add(champion2);
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(2, context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).Count());
                var Test1 = context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).First();
                Test1.Name = "Toto";
                context.SaveChanges();
            }
            
            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(1, context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).Count());
                Assert.Equal(1, context.ChampionSet.Where(c => c.Name.ToLower().Contains("toto")).Count());
            }

        }
    }
}