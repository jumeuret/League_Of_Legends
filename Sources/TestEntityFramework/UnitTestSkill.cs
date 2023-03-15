using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestSkill
{
    
    [Theory]
    [InlineData("Je suis la description de skill1", 111, "Je suis le nom de skill1", "Je suis le type de skill1", 1)]
    [InlineData("Je suis la description de skill2", 112, "Je suis le nom de skill2", "Je suis le type de skill2", 2)]

    public void AddSkill_Test(string description, int id, string name, string type, int nb)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddSkillDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            SkillEntity skill = new SkillEntity()
            {
                Description = description,
                Id = id,
                Name = name,
                Type = type
            };
                    
            context.SkillSet.Add(skill);

            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();
                
            Assert.Equal(nb, context.SkillSet.Count());
            Assert.Equal(description, context.SkillSet.Last().Description);
            Assert.Equal(id, context.SkillSet.Last().Id);
            Assert.Equal(name, context.SkillSet.Last().Name);
            Assert.Equal(type, context.SkillSet.Last().Type);
                
        }
    }
}