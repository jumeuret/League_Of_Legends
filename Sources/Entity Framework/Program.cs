using Model;

namespace Entity_Framework
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            using (var context = new ChampionDbContext())
            {
                context.Champions.AddRange(new ChampionEntity
                {
                    Name = "Test1",
                    Bio = "Je suis un test",
                    Icon = "Je suis l'icone du test",
                },
                new ChampionEntity
                {
                    Name = "Test2",
                    Bio = "Je suis un test",
                    Icon = "Je suis l'icone du test",
                },
                new ChampionEntity
                {
                    Name = "Test3",
                    Bio = "Je suis un test",
                    Icon = "Je suis l'icone du test",
                }
                );
                context.SaveChangesAsync();
            }
                

     
        }
    }
}