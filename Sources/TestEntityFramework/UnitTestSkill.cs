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
            context.Database.EnsureCreated();
                
            Assert.Equal(1, context.SkillSet.Count());
            Assert.Equal(description, context.SkillSet.Last().Description);
            Assert.Equal(id, context.SkillSet.Last().Id);
            Assert.Equal(name, context.SkillSet.Last().Name);
            Assert.Equal(type, context.SkillSet.Last().Type);
                
            context.SkillSet.Remove(skill);

            context.SaveChanges();
        }
    }
    
    [Theory]
    [InlineData("Je suis la description de skill1", 111, "Je suis le nom de skill1", "Je suis le type de skill1", "Je suis la description de skill2", "Je suis le nom de skill2", "Je suis le type de skill2")]
    [InlineData("Je suis la description de skill3", 113, "Je suis le nom de skill3", "Je suis le type de skill3", "Je suis la description de skill4", "Je suis le nom de skill4", "Je suis le type de skill4")]

    public void ModifySkill_Test(string old_description, int id, string old_name, string old_type, string new_description, string new_name, string new_type)
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ModifySkillDB")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Database.EnsureCreated();

            SkillEntity skill = new SkillEntity()
            {
                Description = old_description,
                Id = id,
                Name = old_name,
                Type = old_type
            };
                    
            context.SkillSet.Add(skill);

            context.SaveChanges();

            context.SkillSet.Last().Description = new_description;
            context.SkillSet.Last().Name = new_name;
            context.SkillSet.Last().Type = new_type;
            
            context.SkillSet.Update(skill);

            context.SaveChanges();
                
            Assert.Equal(1, context.SkillSet.Count());
            Assert.NotEqual(old_description, context.SkillSet.Last().Description);
            Assert.Equal(new_description, context.SkillSet.Last().Description);
            Assert.NotEqual(old_name, context.SkillSet.Last().Name);
            Assert.Equal(new_name, context.SkillSet.Last().Name);
            Assert.NotEqual(old_type, context.SkillSet.Last().Type);
            Assert.Equal(new_type, context.SkillSet.Last().Type);
                
            context.SkillSet.Remove(skill);

            context.SaveChanges();
        }
    }
}