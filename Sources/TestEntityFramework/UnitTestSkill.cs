using Entity_Framework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestEntityFramework;

public class UnitTestSkill
{
    
    [Theory]
    [InlineData("Je suis la description de skill1", 111, "Je suis le nom de skill1", "Je suis le type de skill1")]
    [InlineData("Je suis la description de skill2", 112, "Je suis le nom de skill2", "Je suis le type de skill2")]

    public void AddSkill_Test(string description, int id, string name, string type)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
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
                
            Assert.Equal(1, context.SkillSet.Count());
            Assert.Equal(description, context.SkillSet.First().Description);
            Assert.Equal(id, context.SkillSet.First().Id);
            Assert.Equal(name, context.SkillSet.First().Name);
            Assert.Equal(type, context.SkillSet.First().Type);
                
        }
    }
}