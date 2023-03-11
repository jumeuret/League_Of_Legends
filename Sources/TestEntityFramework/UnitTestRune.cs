using System.ComponentModel;
using System.Reflection.PortableExecutable;
using Entity_Framework;
using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestRune
{
    [Theory]
    [InlineData(1, "Je suis le nom de rune1", "Je suis la description de rune1", "Je suis la categorie de rune1", 
        "Je suis la famille de rune1", "Je suis l_image de rune1", "Je suis l_icone de rune1", 1)]
    [InlineData(2, "Je suis le nom de rune2", "Je suis la description de rune2", "Je suis la categorie de rune2", 
        "Je suis la famille de rune2", "Je suis l_image de rune2", "Je suis l_icone de rune2", 2)]

    public void AddCharacteristic_Test(int id, string nom, string description, string categorie, string famille, string icone, string image, int nb)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddRuneDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            RuneEntity rune = new RuneEntity()
            {
                Id = id,
                Name = nom,
                Description = description,
                Categorie = categorie,
                Family = famille,
                Icon = icone,
                Image = image,
            };
                    
            context.RuneSet.Add(rune);

            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
                
            Assert.Equal(nb, context.RuneSet.Count());
            Assert.Equal(id, context.RuneSet.Last().Id);
            Assert.Equal(nom, context.RuneSet.Last().Name);
            Assert.Equal(description, context.RuneSet.Last().Description);
            Assert.Equal(categorie, context.RuneSet.Last().Categorie);
            Assert.Equal(famille, context.RuneSet.Last().Family);
            Assert.Equal(icone, context.RuneSet.Last().Icon);
            Assert.Equal(image, context.RuneSet.Last().Image);
                
        }
    }
}