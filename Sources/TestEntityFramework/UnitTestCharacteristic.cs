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
                
            Assert.Equal(1, context.CharacteristicSet.Count());
            Assert.Equal(nom, context.CharacteristicSet.Last().Nom);
            Assert.Equal(niveau, context.CharacteristicSet.Last().Niveau);

            context.CharacteristicSet.Remove(characteristic);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData("Je suis le nom de caracteristique1", 1, 2)]
    [InlineData("Je suis le nom de caracteristique3", 3, 4)]

    public void ModifyCharacteristic_Test(string nom, int old_niveau, int new_niveau)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ModifyCharacteristicDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            CharacteristicsEntity characteristic = new CharacteristicsEntity
            {
                Nom = nom,
                Niveau = old_niveau
            };
                    
            context.CharacteristicSet.Add(characteristic);

            context.SaveChanges();

            context.CharacteristicSet.Last().Niveau = new_niveau;

            context.Update(characteristic);

            context.SaveChanges();
            
            Assert.Equal(1, context.CharacteristicSet.Count());
            Assert.NotEqual(old_niveau, context.CharacteristicSet.Last().Niveau);
            Assert.Equal(new_niveau, context.CharacteristicSet.Last().Niveau);
                
            context.CharacteristicSet.Remove(characteristic);

            context.SaveChanges();
        }
    }
}