using System.Linq;
using Entity_Framework;
using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Xunit;

namespace TestEntityFramework
{
    public class UnitTestChampion
    {
        public static IEnumerable<Object[]> GetSkins()
        {
            yield return new object[]
            {
                new List<Object>()
                {
                    new SkinEntity()
                    {
                        Description = "Je suis la description de skin1",
                        Icon = "Je suis l'icone de skin1",
                        Id = 11,
                        Image = "Je suis l'image de skin1",
                        Name = "Je suis le nom de skin1",
                        Price = (float)1.1
                    },
                    new SkinEntity()
                    {
                        Description = "Je suis la description de skin2",
                        Icon = "Je suis l'icone de skin2",
                        Id = 12,
                        Image = "Je suis l'image de skin2",
                        Name = "Je suis le nom de skin2",
                        Price = (float)1.2
                    }
                }
            };
        }
        
        public static IEnumerable<Object[]> GetCharacteristics()
        {
            yield return new object[]
            {
                new List<Object>()
                {
                    new CharacteristicsEntity()
                    {
                        Nom = "Je suis le nom de caracteristique1",
                        Niveau = 1
                    },
                    new CharacteristicsEntity()
                    {
                        Nom = "Je suis le nom de caracteristique1",
                        Niveau = 2
                    }
                }
            };
        }
/*
        [Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1"), 
         MemberData(nameof(GetSkins)), MemberData(nameof(GetCharacteristics))]
        
        public void AddChampion_Test(int id, string bio, string icone, string image, string classe, IEnumerable<Object[]> skins, IEnumerable<Object[]> characteristics)
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
        
        */
        /*[Theory]
        [InlineData(1, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Je suis la classe du test1")]*/

        public void AddChampion_Test(int id, string name, string bio, string icone, string image, string classe)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion = new ChampionEntity()
                {
                    Id = id,
                    Name = name,
                    Bio = bio,
                    Icon = icone,
                    Image = image,
                    Class = classe
                };

                context.ChampionSet.Add(champion);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(1, context.ChampionSet.Count());
                
                Assert.Equal(id, context.ChampionSet.First().Id);
                Assert.Equal(name, context.ChampionSet.First().Name);
                Assert.Equal(bio, context.ChampionSet.First().Bio);
                Assert.Equal(icone, context.ChampionSet.First().Icon);
                Assert.Equal(image, context.ChampionSet.First().Image);
                Assert.Equal(classe, context.ChampionSet.First().Class);
            }
        }

        [Fact]
        public void ModifyChampion_Test()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity champion1 = new ChampionEntity
                {
                    Name = "Test1",
                    Bio = "Je suis la bio du test1",
                    Icon = "Je suis l'icone du test1",
                };
                ChampionEntity champion2 = new ChampionEntity
                {
                    Name = "Test2",
                    Bio = "Je suis la bio du test2",
                    Icon = "Je suis l'icon du test2",
                };

                context.ChampionSet.Add(champion1);
                context.ChampionSet.Add(champion2);
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(2, context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).Count());
                var Test1 = context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).First();
                Test1.Name = "Toto";
                context.SaveChanges();
            }
            
            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(1, context.ChampionSet.Where(c => c.Name.ToLower().Contains("test")).Count());
                Assert.Equal(1, context.ChampionSet.Where(c => c.Name.ToLower().Contains("toto")).Count());
            }

        }
    }
}