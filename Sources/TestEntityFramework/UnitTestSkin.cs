using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestSkin
{
    [Theory]
    [InlineData("Je suis la description de skin1", "Je suis l'icone de skin1", 11, "Je suis l'image de skin1", "Je suis le nom de skin1", 1.1, 1)]
    [InlineData("Je suis la description de skin2", "Je suis l'icone de skin2", 12, "Je suis l'image de skin2", "Je suis le nom de skin2", 1.2, 2)]

    public void AddSkin_Test(string description, string icone, int id, string image, string name, float price, int nb)
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
        }

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
                
            Assert.Equal(nb, context.SkinSet.Count());
            Assert.Equal(description, context.SkinSet.Last().Description);
            Assert.Equal(icone, context.SkinSet.Last().Icon);
            Assert.Equal(id, context.SkinSet.Last().Id);
            Assert.Equal(image, context.SkinSet.Last().Image);
            Assert.Equal(name, context.SkinSet.Last().Name);
            Assert.Equal(price, context.SkinSet.Last().Price);
                
        }
    }
}