using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework
{
    public class UnitTestChampion
    {

        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1",
            "Je suis la classe du test1", 1)]
        [InlineData(2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2",
            "Je suis la classe du test2", 2)]
        public void AddChampion_Test(int id, string name, string bio, string icon, string image, string classe, int nb)
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
                    Icon = icon,
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
                Assert.Equal(icon, context.ChampionSet.Last().Icon);
                Assert.Equal(image, context.ChampionSet.Last().Image);
                Assert.Equal(classe, context.ChampionSet.Last().Class);
            }
        }

        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1",
            "Je suis la classe du test1",
            2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2",
            "Je suis la classe du test2")]
        [InlineData(3, "Test3", "Je suis la bio du test3", "Je suis l_icone du test3", "Je suis l_image du test3",
            "Je suis la classe du test3",
            4, "Test4", "Je suis la bio du test4", "Je suis l_icone du test4", "Je suis l_image du test4",
            "Je suis la classe du test4")]
        public void DeleteChampion_Test(int id1, string name1, string bio1, string icone1, string image1,
            string classe1,
            int id2, string name2, string bio2, string icone2, string image2, string classe2)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteChampionDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion1 = new ChampionEntity()
                {
                    Id = id1,
                    Name = name1,
                    Bio = bio1,
                    Icon = icone1,
                    Image = image1,
                    Class = classe1,
                };

                ChampionEntity champion2 = new ChampionEntity()
                {
                    Id = id2,
                    Name = name2,
                    Bio = bio2,
                    Icon = icone2,
                    Image = image2,
                    Class = classe2,
                };

                context.ChampionSet.AddRange(champion1, champion2);
                context.SaveChanges();

                Assert.Equal(2, context.ChampionSet.Count());
                context.ChampionSet.Remove(champion2);
                context.SaveChanges();
                Assert.Equal(1, context.ChampionSet.Count());
                context.Database.EnsureDeleted();
            }
        }
        
        [Fact]
        public void ModifyChampion_Test()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ModifyChampionDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();
                
                ChampionEntity champion1 = new ChampionEntity
                {
                    Name = "Test1",
                    Bio = "Je suis la bio du test1",
                    Icon = "Je suis l'icone du test1",
                    Class = "Je suis la class du test1",
                    Image = "Je suis l'image du test1"
                };
                ChampionEntity champion2 = new ChampionEntity
                {
                    Name = "Test2",
                    Bio = "Je suis la bio du test2",
                    Icon = "Je suis l'icon du test2",
                    Class = "Je suis la class du test2",
                    Image = "Je suis l'image du test2"
                };

                context.ChampionSet.Add(champion1);
                context.ChampionSet.Add(champion2);
                context.SaveChanges();
                Assert.Equal(2, context.ChampionSet.Count());
                context.Database.EnsureDeleted();
            }

           /* using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();
                ChampionEntity champion2 = new ChampionEntity
                {
                    Name = "Test2",
                    Bio = "Je suis la bio du test2",
                    Icon = "Je suis l'icon du test2",
                };

                Assert.Equal(champion2, context.ChampionSet.Single(c => c.Name =="Test2"));
                /*var Test1 = context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).First();
                Test1.Name = "Toto";
                Assert.Equal(2, context.ChampionSet.Where(c => c.Name.ToLower().Contains("toto")).Count());
                context.SaveChanges();
            }*/
            
           /* using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();
                Assert.Equal(1, context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).Count());
                Assert.Equal(1, context.ChampionSet.Where(c => c.Name.ToLower().Contains("toto")).Count());
            }*/

        }
    }
}