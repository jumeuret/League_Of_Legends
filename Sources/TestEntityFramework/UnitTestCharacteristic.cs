using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestCharacteristic
{
    [Theory]
    [InlineData("Je suis le nom de caracteristique1", 1, 1)]
    [InlineData("Je suis le nom de caracteristique2", 2, 2)]

    public void AddCharacteristic_Test(string nom, int niveau, int nb)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddCharacteristicDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            CharacteristicsEntity characteristic = new CharacteristicsEntity
            {
                Nom = nom,
                Niveau = niveau
            };
                    
            context.CharacteristicSet.Add(characteristic);

            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
                
            Assert.Equal(nb, context.CharacteristicSet.Count());
            Assert.Equal(nom, context.CharacteristicSet.Last().Nom);
            Assert.Equal(niveau, context.CharacteristicSet.Last().Niveau);
                
        }
    }
}