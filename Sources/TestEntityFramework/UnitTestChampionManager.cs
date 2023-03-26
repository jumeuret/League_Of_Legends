using Entity_Framework;
using Entity_Framework.Mapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;

namespace TestEntityFramework;

public class UnitTestChampionManager
{
    
    [Theory]
    [InlineData(10, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Marksman")]
    public void ChampionManagerTest_GetById(int id, string name, string bio, string icon, string image, string classe)
    {
        var champion = new Champion(id, name, (ChampionClass)Enum.Parse(typeof(ChampionClass), classe), icon, image,bio);
        
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetByIdDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
            var championEntity = new ChampionEntity { Id = id, Name = name, Bio = bio, Image = image, Class = classe };
            context.ChampionSet.Add(championEntity);
            context.SaveChanges();
        }
        
        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
            var champManager = new ChampionManager();

            var result = champManager.GetById(id).Result;
            
            Assert.Equal(champion, result);
            Assert.Equal(champion.Name, result.Name);
            Assert.Equal(champion.Bio, result.Bio);
            Assert.Equal(champion.Icon, result.Icon);
            Assert.Equal(champion.Image, result.Image);
            Assert.Equal(champion.Class, result.Class);

            context.Database.EnsureDeleted();
        }
    }

    /*[Theory]
    [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1", "Je suis me nom du nouveau champion")]
    [InlineData(2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Je suis la classe du test2", "Je suis me nom du nouveau champion")]
    public void championManagerTest_updateItem(int id, string name, string bio, string icon, string image, string classe, string name2)
    {
        var oldChampionEntity = new ChampionEntity
            { Id = id, Name = name, Icon = icon, Bio = bio, Image = image, Class = classe };
        var newChampionEntity = new ChampionEntity
            { Id = id, Name = name2, Icon = icon, Bio = bio, Image = image, Class = classe };
        
        var oldChampion = new Champion(name, (ChampionClass)Enum.Parse(typeof(ChampionClass), classe), icon, image,bio);
        var newChampion = new Champion(name2, (ChampionClass)Enum.Parse(typeof(ChampionClass), classe), icon, image,bio);

        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        
        Assert.Equal(2,2);
        
       /* var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "UpdateItemDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            context.ChampionSet.Add(oldChampionEntity);
            context.SaveChanges();


            var championManager = new ChampionManager();

            var championUpdate = championManager.UpdateItem(oldChampion, newChampion).Result;
            
            Assert.Equal(newChampion, championUpdate);
            Assert.Equal(newChampion.Bio, championUpdate.Bio);
            Assert.Equal(newChampion.Name, championUpdate.Name);
            Assert.Equal(newChampion.Icon, championUpdate.Icon);
            Assert.Equal(newChampion.Class, championUpdate.Class);
            Assert.Equal(newChampion.Image, championUpdate.Image);
            context.Database.EnsureDeleted();
        }
    }*/

    [Theory]
    [InlineData(10, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Fighter", 1)]
    public void championManagerTest_addItem(int id, string name, string bio, string icon, string image, string classe, int nb)
    {
      
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddItemDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
            var champion = new Champion(id, name,(ChampionClass)Enum.Parse(typeof(ChampionClass), "Assassin"), icon, image, bio);
            var championManager = new ChampionManager();
            var result =  championManager.AddItem(champion).Result;
            context.SaveChanges(); 
            Assert.Equal(nb, context.ChampionSet.Count());
            Assert.Equal(champion, result);
            Assert.Equal(champion.Bio, result.Bio);
            Assert.Equal(champion.Name, result.Name);
            Assert.Equal(champion.Icon, result.Icon);
            Assert.Equal(champion.Class, result.Class);
            Assert.Equal(champion.Image, result.Image);
            context.Database.EnsureDeleted();
            context.Database.EnsureDeleted();
        }
    }
    /*
    public class ChampionRepositoryTests
    {
        [Fact]
        public async Task AddItem_ShouldAddChampionToDatabase()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddChampionToDatabase")
                .Options;

            var champion = new Champion("name",(ChampionClass)Enum.Parse(typeof(ChampionClass), "Assassin"), "icon", "image", "bio");
            
            using (var context = new ApplicationDbContext(options))
            {
                var manager = new ChampionManager();
                await manager.AddItem(champion);
            }

            // Assert
            using (var context = new ApplicationDbContext(options))
            {
                var addedChampion = await context.ChampionSet.FirstOrDefaultAsync(c => c.Name == champion.Name);
                Assert.NotNull(addedChampion);
                Assert.Equal(champion.Name, addedChampion.Name);
            }
        }
        
        public class ChampionManagerTests
        {
            [Fact]
            public async Task GetItem_ShouldReturnChampionFromDatabase()
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "GetChampionFromDatabase")
                    .Options;
                
                var champion = new Champion("name",(ChampionClass)Enum.Parse(typeof(ChampionClass), "Assassin"), "icon", "image", "bio");
                
                using (var context = new ApplicationDbContext(options))
                {
                    var championEntity = champion.ToChampionEntity();
                    context.ChampionSet.Add(championEntity);
                    await context.SaveChangesAsync();

                    var manager = new ChampionManager();

                    var result = await manager.GetById(1);

                    Assert.NotNull(result);
                    Assert.Equal(champion.Name, result.Name);
                }
            }
        }

    }*/


  /* [Theory]
    [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1",
        2, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Je suis la classe du test2")]
    [InlineData(3, "Test", "Je suis la bio du test3", "Je suis l_icone du test3", "Je suis l_image du test3", "Je suis la classe du test3", 
        4, "Test4", "Je suis la bio du test4", "Je suis l_icone du test4", "Je suis l_image du test4","Je suis la classe du test4")]
    public void championManagerTest_deleteItem(int id1, string name1, string bio1, string icon1, string image1, string classe1, 
        int id2, string name2, string bio2, string icon2, string image2, string classe2)
    {
        var championEntity1 = new ChampionEntity{ Id = id1, Name = name1, Icon = icon1, Bio = bio1, Image = image1, Class = classe1 };
        var championEntity2 = new ChampionEntity{ Id = id2, Name = name2, Icon = icon2, Bio = bio2, Image = image2, Class = classe2 };

        var champion2 = new Champion(name2, (ChampionClass)Enum.Parse(typeof(ChampionClass), classe2), icon2, image2, bio2);
        
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "DeleteItemDB")
            .Options;
        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
            context.ChampionSet.AddRange(championEntity1, championEntity2);
            Assert.Equal(2, context.ChampionSet.Count());
            
            var championManager = new ChampionManager();
            var result = championManager.DeleteItem(champion2).Result;
            Assert.True(result);
            Assert.Equal(1, context.ChampionSet.Count());
            Assert.Equal(4, context.ChampionSet.Count());

            context.Database.EnsureDeleted();
        }
    }*/
}