using API_lol.Controllers;
using DTO;
using Model;

namespace TestApiRest;

public class UnitTest1
{
    [Fact]
    public void Test_ContructeurDTOValideName()
    {
        ChampionDTO championDto = new ChampionDTO(1, "Ivern", "test bio", "test icon");
        Assert.NotNull(championDto);
        Assert.Equal("Ivern", championDto.Name);
    }
    [Fact]
    public void Test_ContructeurDTOValideIcon()
    {
        ChampionDTO championDto = new ChampionDTO(1, "Ivern", "test bio", "test icon");
        Assert.NotNull(championDto);
        Assert.Equal("test icon", championDto.Icon);
    }
        
    [Fact]
    public void Test_ContructeurDTOValideBio()
    {
        ChampionDTO championDto = new ChampionDTO(1, "Ivern", "test bio", "test icon");
        Assert.NotNull(championDto);
        Assert.Equal("test bio", championDto.Bio);
    }
        
    [Fact]
    public void Test_GetChampion()
    {
       
    }
}