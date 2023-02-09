using Model;

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
                    Name = "Test1",
                    Bio = "Je suis un test",
                    Icon = "Je suis l'icone du test",
                    Image = "Je suis une image",
                    Class = "Je suis une classe",
                },
                new ChampionEntity
                {
                    Name = "Test2",
                    Bio = "Je suis un test",
                    Icon = "Je suis l'icone du test",
                    Image = "Je suis une image",
                    Class = "Je suis une classe",
                },
                new ChampionEntity
                {
                    Name = "Test3",
                    Bio = "Je suis un test",
                    Icon = "Je suis l'icone du test",
                    Image = "Je suis une image",
                    Class = "Je suis une classe",
                }
                );
                context.SaveChangesAsync();
            }
            using (var context = new RuneDbContext())
            {
                context.Pages.AddRange(new RunePageEntity
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