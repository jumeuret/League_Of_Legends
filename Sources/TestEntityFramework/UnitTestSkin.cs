using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestSkin
{
    [Theory]
    [InlineData("Je suis la description de skin1", "Je suis l'icone de skin1", 11, "Je suis l'image de skin1", "Je suis le nom de skin1", 1.1)]
    [InlineData("Je suis la description de skin2", "Je suis l'icone de skin2", 12, "Je suis l'image de skin2", "Je suis le nom de skin2", 1.2)]

    public void AddSkin_Test(string description, string icone, int id, string image, string name, float price)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddSkinDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            SkinEntity skin = new SkinEntity
            {
                Description = description,
                Icon = icone,
                Id = id,
                Image = image,
                Name = name,
                Price = price
            };
                    
            context.SkinSet.Add(skin);

            context.SaveChanges();

            Assert.Equal(1, context.SkinSet.Count());
            Assert.Equal(description, context.SkinSet.Last().Description);
            Assert.Equal(icone, context.SkinSet.Last().Icon);
            Assert.Equal(id, context.SkinSet.Last().Id);
            Assert.Equal(image, context.SkinSet.Last().Image);
            Assert.Equal(name, context.SkinSet.Last().Name);
            Assert.Equal(price, context.SkinSet.Last().Price);
                
            context.SkinSet.Remove(skin);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData("Je suis la description de skin1", "Je suis l'icone de skin1", 11, "Je suis l'image de skin1", "Je suis le nom de skin1", 1.1, "Je suis la description de skin2", "Je suis l'icone de skin2", "Je suis l'image de skin2", "Je suis le nom de skin2", 1.2)]
    [InlineData("Je suis la description de skin3", "Je suis l'icone de skin3", 13, "Je suis l'image de skin3", "Je suis le nom de skin3", 1.3, "Je suis la description de skin4", "Je suis l'icone de skin4", "Je suis l'image de skin4", "Je suis le nom de skin4", 1.4)]

    public void ModifySkin_Test(string old_description, string old_icone, int id, string old_image, string old_name, float old_price, string new_description, string new_icone, string new_image, string new_name, float new_price)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ModifySkinDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            SkinEntity skin = new SkinEntity
            {
                Description = old_description,
                Icon = old_icone,
                Id = id,
                Image = old_image,
                Name = old_name,
                Price = old_price
            };
                    
            context.SkinSet.Add(skin);

            context.SaveChanges();

            context.SkinSet.Last().Description = new_description;
            context.SkinSet.Last().Icon = new_icone;
            context.SkinSet.Last().Image = new_image;
            context.SkinSet.Last().Name = new_name;
            context.SkinSet.Last().Price = new_price;
            
            context.SkinSet.Update(skin);

            context.SaveChanges();
                
            Assert.Equal(1, context.SkinSet.Count());
            Assert.NotEqual(old_description, context.SkinSet.Last().Description);
            Assert.Equal(new_description, context.SkinSet.Last().Description);
            Assert.NotEqual(old_icone, context.SkinSet.Last().Icon);
            Assert.Equal(new_icone, context.SkinSet.Last().Icon);
            Assert.NotEqual(old_image, context.SkinSet.Last().Image);
            Assert.Equal(new_image, context.SkinSet.Last().Image);
            Assert.NotEqual(old_name, context.SkinSet.Last().Name);
            Assert.Equal(new_name, context.SkinSet.Last().Name);
            Assert.NotEqual(old_price, context.SkinSet.Last().Price);
            Assert.Equal(new_price, context.SkinSet.Last().Price);
            
            context.SkinSet.Remove(skin);

            context.SaveChanges();    
        }
    }
    
    [Theory]
    [InlineData("Je suis la description de skin1", "Je suis l'icone de skin1", 11, "Je suis l'image de skin1", "Je suis le nom de skin1", 1.1)]
    [InlineData("Je suis la description de skin2", "Je suis l'icone de skin2", 12, "Je suis l'image de skin2", "Je suis le nom de skin2", 1.2)]

    public void DeleteSkin_Test(string description, string icone, int id, string image, string name, float price)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "DeleteSkinDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            SkinEntity skin = new SkinEntity
            {
                Description = description,
                Icon = icone,
                Id = id,
                Image = image,
                Name = name,
                Price = price
            };
                    
            context.SkinSet.Add(skin);

            context.SaveChanges();

            Assert.Equal(1, context.SkinSet.Count());
                
            context.SkinSet.Remove(skin);

            context.SaveChanges();
            
            Assert.Equal(0, context.SkinSet.Count());
        }
    }
}