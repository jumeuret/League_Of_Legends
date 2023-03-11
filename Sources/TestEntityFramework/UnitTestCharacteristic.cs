using System.Reflection.PortableExecutable;
using Entity_Framework;
using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestCharacteristic
{
    [Theory]
    [InlineData("Je suis le nom de caracteristique1", 1)]
    [InlineData("Je suis le nom de caracteristique2", 2)]

    public void AddCharacteristic_Test(string nom, int niveau)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
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
                
            Assert.Equal(1, context.CharacteristicSet.Count());
            Assert.Equal(nom, context.CharacteristicSet.First().Nom);
            Assert.Equal(niveau, context.CharacteristicSet.First().Niveau);
                
        }
    }
}