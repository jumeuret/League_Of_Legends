using Entity_Framework;
using EntityFramework.Migrations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestSkin
{
    /*[Theory]
    [InlineData("Je suis la description de skin1", "Je suis l'icone de skin1", 11, "Je suis l'image de skin1", "Je suis le nom de skin1", 1.1)]
    [InlineData("Je suis la description de skin2", "Je suis l'icone de skin2", 12, "Je suis l'image de skin2", "Je suis le nom de skin2", 1.2)]

    public void AddSkin_Test(string description, string icone, int id, string image, string name, float price)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
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
                
            Assert.Equal(1, context.SkinSet.Count());
            Assert.Equal(description, context.SkinSet.First().Description);
            Assert.Equal(icone, context.SkinSet.First().Icon);
            Assert.Equal(id, context.SkinSet.First().Id);
            Assert.Equal(image, context.SkinSet.First().Image);
            Assert.Equal(name, context.SkinSet.First().Name);
            Assert.Equal(price, context.SkinSet.First().Price);
                
        }
    }*/
}