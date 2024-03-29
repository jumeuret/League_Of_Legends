using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework
{
    public class UnitTestChampion
    {
        
        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1")]
        [InlineData(2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Je suis la classe du test2")]

        public void AddChampion_Test(int id, string name, string bio, string icone, string image, string classe)
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
                
                Assert.Equal(1, context.ChampionSet.Count());
                Assert.Equal(id, context.ChampionSet.Last().Id);
                Assert.Equal(name, context.ChampionSet.Last().Name);
                Assert.Equal(bio, context.ChampionSet.Last().Bio);
                Assert.Equal(icone, context.ChampionSet.Last().Icon);
                Assert.Equal(image, context.ChampionSet.Last().Image);
                Assert.Equal(classe, context.ChampionSet.Last().Class);

                context.ChampionSet.Remove(champion);

                context.SaveChanges();
            }
            
        }

        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1", "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Je suis la classe du test2")]
        [InlineData(3, "Test3", "Je suis la bio du test3", "Je suis l_icone du test3", "Je suis l_image du test3", "Je suis la classe du test3", "Test4", "Je suis la bio du test4", "Je suis l_icone du test4", "Je suis l_image du test4", "Je suis la classe du test4")]
        
        public void ModifyChampion_Test(int id, string old_name, string old_bio, string old_icone, string old_image, string old_classe, string new_name, string new_bio, string new_icone, string new_image, string new_classe)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ModifyChampionDB")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion = new ChampionEntity()
                {
                    Id =  id,
                    Name =  old_name,
                    Bio = old_bio,
                    Icon =  old_icone,
                    Image =  old_image,
                    Class =  old_classe,
                };
                
                context.ChampionSet.Add(champion);
                
                context.SaveChanges();

                context.ChampionSet.Last().Name = new_name;
                context.ChampionSet.Last().Bio = new_bio;
                context.ChampionSet.Last().Icon = new_icone;
                context.ChampionSet.Last().Image = new_image;
                context.ChampionSet.Last().Class = new_classe;
                
                context.ChampionSet.Update(champion);
                
                context.SaveChanges();
                
                Assert.Equal(1, context.ChampionSet.Count());
                Assert.NotEqual(old_name, context.ChampionSet.Last().Name);;
                Assert.Equal(new_name, context.ChampionSet.Last().Name);
                Assert.NotEqual(old_bio, context.ChampionSet.Last().Bio);;
                Assert.Equal(new_bio, context.ChampionSet.Last().Bio);
                Assert.NotEqual(old_icone, context.ChampionSet.Last().Icon);;
                Assert.Equal(new_icone, context.ChampionSet.Last().Icon);
                Assert.NotEqual(old_image, context.ChampionSet.Last().Image);;
                Assert.Equal(new_image, context.ChampionSet.Last().Image);
                Assert.NotEqual(old_classe, context.ChampionSet.Last().Class);;
                Assert.Equal(new_classe, context.ChampionSet.Last().Class);

                context.ChampionSet.Remove(champion);

                context.SaveChanges();
            }
        }
        
        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1")]
        [InlineData(3, "Test3", "Je suis la bio du test3", "Je suis l_icone du test3", "Je suis l_image du test3", "Je suis la classe du test3")]
        public void DeleteChampion_Test(int id1, string name1, string bio1, string icone1, string image1, string classe1)
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

                context.ChampionSet.Add(champion1);
                
                context.SaveChanges();

                Assert.Equal(1, context.ChampionSet.Count());
                
                context.ChampionSet.Remove(champion1);
                
                context.SaveChanges();
                
                Assert.Equal(0, context.ChampionSet.Count());
            }
        }

    }
}