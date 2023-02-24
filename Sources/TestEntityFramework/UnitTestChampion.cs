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
    public class UnitTest1
    {
              
        [Fact]
        public void AddChampion_Test()
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
                    Id = 1,
                    Name = "Test1",
                    Bio = "Je suis la bio du test1",
                    Icon = "Je suis l'icone du test1",
                    Image = "Je suis l'image du test1",
                    Class = "Je suis la classe du test1",
                    Skins = new List<SkinEntity>()
                    { new SkinEntity()
                        {
                            Description = "Je suis la description de skin1",
                            Icon = "Je suis l'icone de skin1",
                            Id = 11,
                            Image = "Je suis l'image de skin1",
                            Name = "Je suis le nom de skin1",
                            Price = (float)1.1,
                        }, new SkinEntity()
                        {
                            Description = "Je suis la description de skin2",
                            Icon = "Je suis l'icone de skin2",
                            Id = 12,
                            Image = "Je suis l'image de skin2",
                            Name = "Je suis le nom de skin2",
                            Price = (float)1.2,
                        }
                    },
                    Characteristics = new List<CharasteristicsEntity>()
                    { new CharasteristicsEntity()
                        {
                            Nom = "Je suis le nom de caracteristique1",
                            Niveau = 1,
                        },
                        new CharasteristicsEntity()
                        {
                            Nom = "Je suis le nom de caracteristique2",
                            Niveau = 2,
                        }
                    },
                    Skills = new List<SkillEntity>()
                    {
                        new SkillEntity()
                        {
                            Description = "Je suis la description de skill1",
                            Id = 111,
                            Name = "Je suis le nom de skill1",
                            Type = "Je suis le type de skill1",
                        },
                        new SkillEntity()
                        {
                            Description = "Je suis la description de skill2",
                            Id = 112,
                            Name = "Je suis le nom de skill2",
                            Type = "Je suis le type de skill2",
                        }
                    }
                };
                
                ChampionEntity champion2 = new ChampionEntity
                {
                    Id = 2,
                    Name = "Test2",
                    Bio = "Je suis la bio du test2",
                    Icon = "Je suis l'icone du test2",
                    Image = "Je suis l'image du test2",
                    Class = "Je suis la classe du test2",
                    Skins = new List<SkinEntity>()
                    { new SkinEntity
                        {
                            Description = "Je suis la description de skin3",
                            Icon = "Je suis l'icone de skin3",
                            Id = 23,
                            Image = "Je suis l'image de skin3",
                            Name = "Je suis le nom de skin3",
                            Price = (float)2.3,
                        }, new SkinEntity
                        {
                            Description = "Je suis la description de skin4",
                            Icon = "Je suis l'icone de skin4",
                            Id = 24,
                            Image = "Je suis l'image de skin4",
                            Name = "Je suis le nom de skin4",
                            Price = (float)2.4,
                        }
                    },
                    Characteristics = new List<CharasteristicsEntity>()
                    { new CharasteristicsEntity()
                        {
                            Nom = "Je suis le nom de caracteristique3",
                            Niveau = 13,
                        },
                        new CharasteristicsEntity()
                        {
                            Nom = "Je suis le nom de caracteristique4",
                            Niveau = 14,
                        }
                    },
                    Skills = new List<SkillEntity>()
                    {
                        new SkillEntity()
                        {
                            Description = "Je suis la description de skill3",
                            Id = 113,
                            Name = "Je suis le nom de skill3",
                            Type = "Je suis le type de skill3",
                        },
                        new SkillEntity()
                        {
                            Description = "Je suis la description de skill4",
                            Id = 114,
                            Name = "Je suis le nom de skill4",
                            Type = "Je suis le type de skill4",
                        }
                    }
                };

                context.ChampionSet.Add(champion1);
                context.ChampionSet.Add(champion2);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(2, context.ChampionSet.Count());
                
                Assert.Equal(1, context.ChampionSet.First().Id);
                Assert.Equal("Test1", context.ChampionSet.First().Name);
                Assert.Equal("Je suis la bio du test1", context.ChampionSet.First().Bio);
                Assert.Equal("Je suis l'icone du test1", context.ChampionSet.First().Icon);
                Assert.Equal("Je suis l'image du test1", context.ChampionSet.First().Image);
                Assert.Equal("Je suis la classe du test1", context.ChampionSet.First().Class);
                
                Assert.Equal("Je suis la description de skin1", context.ChampionSet.First().Skins.First().Description);
                Assert.Equal("Je suis l'icone de skin1", context.ChampionSet.First().Skins.First().Icon);
                Assert.Equal(11, context.ChampionSet.First().Skins.First().Id);
                Assert.Equal("Je suis l'image de skin1", context.ChampionSet.First().Skins.First().Image);
                Assert.Equal("Je suis le nom de skin1", context.ChampionSet.First().Skins.First().Name);
                Assert.Equal(1.1, context.ChampionSet.First().Skins.First().Price);
                
                Assert.Equal("Je suis la description de skin2", context.ChampionSet.First().Skins.Last().Description);
                Assert.Equal("Je suis l'icone de skin2", context.ChampionSet.First().Skins.Last().Icon);
                Assert.Equal(12, context.ChampionSet.First().Skins.Last().Id);
                Assert.Equal("Je suis l'image de skin2", context.ChampionSet.First().Skins.Last().Image);
                Assert.Equal("Je suis le nom de skin2", context.ChampionSet.First().Skins.Last().Name);
                Assert.Equal(1.2, context.ChampionSet.First().Skins.Last().Price);
                
                Assert.Equal("Je suis le nom de caracteristique1", context.ChampionSet.First().Characteristics.First().Nom);
                Assert.Equal(1, context.ChampionSet.First().Characteristics.First().Niveau);
                
                Assert.Equal("Je suis le nom de caracteristique2", context.ChampionSet.First().Characteristics.Last().Nom);
                Assert.Equal(2, context.ChampionSet.First().Characteristics.Last().Niveau);
                
                Assert.Equal("Je suis la description de skill1", context.ChampionSet.First().Skills.First().Description);
                Assert.Equal(111, context.ChampionSet.First().Skills.First().Id);
                Assert.Equal("Je suis le nom de skill1", context.ChampionSet.First().Skills.First().Name);
                Assert.Equal("Je suis le type de skill1", context.ChampionSet.First().Skills.First().Type);
                
                Assert.Equal("Je suis la description de skill2", context.ChampionSet.First().Skills.Last().Description);
                Assert.Equal(112, context.ChampionSet.First().Skills.Last().Id);
                Assert.Equal("Je suis le nom de skill2", context.ChampionSet.First().Skills.Last().Name);
                Assert.Equal("Je suis le type de skill2", context.ChampionSet.First().Skills.Last().Type);
                
                
                Assert.Equal(2, context.ChampionSet.Last().Id);
                Assert.Equal("Test2", context.ChampionSet.Last().Name);
                Assert.Equal("Je suis la bio du test2", context.ChampionSet.Last().Bio);
                Assert.Equal("Je suis l'icone du test2", context.ChampionSet.Last().Icon);
                Assert.Equal("Je suis l'image du test2", context.ChampionSet.Last().Image);
                Assert.Equal("Je suis la classe du test2", context.ChampionSet.Last().Class);
                
                Assert.Equal("Je suis la description de skin3", context.ChampionSet.Last().Skins.First().Description);
                Assert.Equal("Je suis l'icone de skin3", context.ChampionSet.Last().Skins.First().Icon);
                Assert.Equal(23, context.ChampionSet.Last().Skins.First().Id);
                Assert.Equal("Je suis l'image de skin3", context.ChampionSet.Last().Skins.First().Image);
                Assert.Equal("Je suis le nom de skin3", context.ChampionSet.Last().Skins.First().Name);
                Assert.Equal(2.3, context.ChampionSet.Last().Skins.First().Price);
                
                Assert.Equal("Je suis la description de skin4", context.ChampionSet.Last().Skins.Last().Description);
                Assert.Equal("Je suis l'icone de skin4", context.ChampionSet.Last().Skins.Last().Icon);
                Assert.Equal(24, context.ChampionSet.Last().Skins.Last().Id);
                Assert.Equal("Je suis l'image de skin4", context.ChampionSet.Last().Skins.Last().Image);
                Assert.Equal("Je suis le nom de skin4", context.ChampionSet.Last().Skins.Last().Name);
                Assert.Equal(2.4, context.ChampionSet.Last().Skins.Last().Price);
                
                Assert.Equal("Je suis le nom de caracteristique3", context.ChampionSet.Last().Characteristics.First().Nom);
                Assert.Equal(13, context.ChampionSet.Last().Characteristics.First().Niveau);
                
                Assert.Equal("Je suis le nom de caracteristique4", context.ChampionSet.Last().Characteristics.Last().Nom);
                Assert.Equal(14, context.ChampionSet.Last().Characteristics.Last().Niveau);
                
                Assert.Equal("Je suis la description de skill3", context.ChampionSet.Last().Skills.First().Description);
                Assert.Equal(113, context.ChampionSet.Last().Skills.First().Id);
                Assert.Equal("Je suis le nom de skill3", context.ChampionSet.Last().Skills.First().Name);
                Assert.Equal("Je suis le type de skill3", context.ChampionSet.Last().Skills.First().Type);
                
                Assert.Equal("Je suis la description de skill4", context.ChampionSet.Last().Skills.Last().Description);
                Assert.Equal(114, context.ChampionSet.Last().Skills.Last().Id);
                Assert.Equal("Je suis le nom de skill4", context.ChampionSet.Last().Skills.Last().Name);
                Assert.Equal("Je suis le type de skill4", context.ChampionSet.Last().Skills.Last().Type);
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