using Model;
using StubLib;

namespace Entity_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                context.ChampionSet.AddRange(new ChampionEntity
                {
                    Id = 1,
                    Name = "Champion1",
                    Bio = "Je suis un champion",
                    Icon = "Je suis l'icone du champion",
                    Image = "Je suis une image",
                    Class = "Je suis une classe",
                },
                new ChampionEntity
                {
                    Name = "Champion2",
                    Bio = "Je suis un champion",
                    Icon = "Je suis l'icone du champion",
                    Image = "Je suis une image",
                    Class = "Je suis une classe",
                },
                new ChampionEntity
                {
                    Name = "Champion3",
                    Bio = "Je suis un champion",
                    Icon = "Je suis l'icone du champion",
                    Image = "Je suis une image",
                    Class = "Je suis une classe",
                }
                );
                context.SaveChangesAsync();
                
                context.RunePageSet.AddRange(new RunePageEntity
                    {
                        Name = "Test1",
                    },
                    new RunePageEntity
                    {
                        Name = "Test2",
                    },
                    new RunePageEntity
                    {
                        Name = "Test3",
                    }
                );
                context.SaveChangesAsync();
            }
        }
    }
}