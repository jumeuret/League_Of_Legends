using Model;

namespace MsTesApiRest
{
    [TestClass]
    public class UnitTestChampion
    {
        [TestMethod]
        public async Task GetChampion_ReturnCodeSucces()
        {
            // Arrange 
            var champions = new List<Champion> ()
            {
            new Champion("Akali", ChampionClass.Assassin),
            new Champion("Aatrox", ChampionClass.Fighter),
            new Champion("Ahri", ChampionClass.Mage),
            new Champion("Akshan", ChampionClass.Marksman),
            new Champion("Bard", ChampionClass.Support),
            new Champion("Alistar", ChampionClass.Tank),
            };
            // Act
/*            List<Champion> result = await service
*/
        // Assert
       /* var result = await SomeAsyncOperation();
            Assert.AreEqual(champions, );*/
        }
    }
}