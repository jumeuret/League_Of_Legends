using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework
{
    public class UnitTestChampion
    {
        
        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1", 1)]
        [InlineData(2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Je suis la classe du test2", 2)]
        
        
        public void AddChampion_Test(int id, string name, string bio, string icone, string image, string classe, int nb)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddChampionDB")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion = new ChampionEntity()
                {
                    Id = id,
                    Name = name,
                    Bio = bio,
                    Icon = icone,
                    Image = image,
                    Class = classe,
                };
                
                context.ChampionSet.Add(champion);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();
                
                Assert.Equal(nb, context.ChampionSet.Count());
                Assert.Equal(id, context.ChampionSet.Last().Id);
                Assert.Equal(name, context.ChampionSet.Last().Name);
                Assert.Equal(bio, context.ChampionSet.Last().Bio);
                Assert.Equal(icone, context.ChampionSet.Last().Icon);
                Assert.Equal(image, context.ChampionSet.Last().Image);
                Assert.Equal(classe, context.ChampionSet.Last().Class);
            }
        }

        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1", 1)]
        [InlineData(2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Je suis la classe du test2", 2)]
        
        public void ModifyChampion_Test(int id, string name, string bio, string icone, string image, string classe, int nb)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddChampionDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion = new ChampionEntity()
                {
                    Id = id,
                    Name = name,
                    Bio = bio,
                    Icon = icone,
                    Image = image,
                    Class = classe,
                };
                
                context.ChampionSet.Add(champion);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();
                
                Assert.Equal(nb, context.ChampionSet.Count());
                Assert.Equal(id, context.ChampionSet.Last().Id);
                Assert.Equal(name, context.ChampionSet.Last().Name);
                Assert.Equal(bio, context.ChampionSet.Last().Bio);
                Assert.Equal(icone, context.ChampionSet.Last().Icon);
                Assert.Equal(image, context.ChampionSet.Last().Image);
                Assert.Equal(classe, context.ChampionSet.Last().Class);
            }
        }
        
        /*

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

        }*/
    }
}