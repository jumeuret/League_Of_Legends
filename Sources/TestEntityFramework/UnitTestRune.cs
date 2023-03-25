using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestRune
{
    [Theory]
    [InlineData(1, "Je suis le nom de rune1", "Je suis la description de rune1", "Je suis la categorie de rune1", 
        "Je suis la famille de rune1", "Je suis l_image de rune1", "Je suis l_icone de rune1")]
    [InlineData(2, "Je suis le nom de rune2", "Je suis la description de rune2", "Je suis la categorie de rune2", 
        "Je suis la famille de rune2", "Je suis l_image de rune2", "Je suis l_icone de rune2")]

    public void AddCharacteristic_Test(int id, string nom, string description, string categorie, string famille, string icone, string image)
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
                
            Assert.Equal(1, context.RuneSet.Count());
            Assert.Equal(id, context.RuneSet.Last().Id);
            Assert.Equal(nom, context.RuneSet.Last().Name);
            Assert.Equal(description, context.RuneSet.Last().Description);
            Assert.Equal(categorie, context.RuneSet.Last().Categorie);
            Assert.Equal(famille, context.RuneSet.Last().Family);
            Assert.Equal(icone, context.RuneSet.Last().Icon);
            Assert.Equal(image, context.RuneSet.Last().Image);

            context.RuneSet.Remove(rune);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData(1, "Je suis le nom de rune1", "Je suis la description de rune1", "Je suis la categorie de rune1", 
        "Je suis la famille de rune1", "Je suis l_image de rune1", "Je suis l_icone de rune1", 
        "Je suis le nom de rune2", "Je suis la description de rune2", "Je suis la categorie de rune2", 
        "Je suis la famille de rune2", "Je suis l_image de rune2", "Je suis l_icone de rune2")]
    [InlineData(3, "Je suis le nom de rune3", "Je suis la description de rune3", "Je suis la categorie de rune3", 
        "Je suis la famille de rune3", "Je suis l_image de rune3", "Je suis l_icone de rune3", 
        "Je suis le nom de rune4", "Je suis la description de rune4", "Je suis la categorie de rune4", 
        "Je suis la famille de rune4", "Je suis l_image de rune4", "Je suis l_icone de rune4")]

    public void ModifyCharacteristic_Test(int id, string old_nom, string old_description, string old_categorie, string old_famille, string old_icone, string old_image, string new_nom, string new_description, string new_categorie, string new_famille, string new_icone, string new_image)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ModifyRuneDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            RuneEntity rune = new RuneEntity()
            {
                Id = id,
                Name = old_nom,
                Description = old_description,
                Categorie = old_categorie,
                Family = old_famille,
                Icon = old_icone,
                Image = old_image,
            };
                    
            context.RuneSet.Add(rune);

            context.SaveChanges();

            context.RuneSet.Last().Name = new_nom;
            context.RuneSet.Last().Description = new_description;
            context.RuneSet.Last().Categorie = new_categorie;
            context.RuneSet.Last().Family = new_famille;
            context.RuneSet.Last().Icon = new_icone;
            context.RuneSet.Last().Image = new_image;
            
            context.RuneSet.Update(rune);

            context.SaveChanges();
                
            Assert.Equal(1, context.RuneSet.Count());
            Assert.NotEqual(old_nom, context.RuneSet.Last().Name);
            Assert.Equal(new_nom, context.RuneSet.Last().Name);
            Assert.NotEqual(old_description, context.RuneSet.Last().Description);
            Assert.Equal(new_description, context.RuneSet.Last().Description);
            Assert.NotEqual(old_categorie, context.RuneSet.Last().Categorie);
            Assert.Equal(new_categorie, context.RuneSet.Last().Categorie);
            Assert.NotEqual(old_famille, context.RuneSet.Last().Family);
            Assert.Equal(new_famille, context.RuneSet.Last().Family);
            Assert.NotEqual(old_icone, context.RuneSet.Last().Icon);
            Assert.Equal(new_icone, context.RuneSet.Last().Icon);
            Assert.NotEqual(old_image, context.RuneSet.Last().Image);
            Assert.Equal(new_image, context.RuneSet.Last().Image);
                
            context.RuneSet.Remove(rune);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData(1, "Je suis le nom de rune1", "Je suis la description de rune1", "Je suis la categorie de rune1", 
        "Je suis la famille de rune1", "Je suis l_image de rune1", "Je suis l_icone de rune1")]
    [InlineData(2, "Je suis le nom de rune2", "Je suis la description de rune2", "Je suis la categorie de rune2", 
        "Je suis la famille de rune2", "Je suis l_image de rune2", "Je suis l_icone de rune2")]

    public void DeleteCharacteristic_Test(int id, string nom, string description, string categorie, string famille, string icone, string image)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "DeleteRuneDB")
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
                
            Assert.Equal(1, context.RuneSet.Count());

            context.RuneSet.Remove(rune);

            context.SaveChanges();
            
            Assert.Equal(0, context.RuneSet.Count());
        }
    }
}