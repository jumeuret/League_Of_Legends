using API_lol.Controllers;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;

namespace TestApiRest;

public class UnitTest1
{
    [Fact]
    public void Test_ContructeurDTOValideName()
    {
        ChampionDTO championDto = new ChampionDTO("Ivern", "test bio", "test icon");
        Assert.NotNull(championDto);
        Assert.Equal("Ivern", championDto.Name);
    }

    [Fact]
    public void Test_ContructeurDTOValideBio()
    {
        ChampionDTO championDto = new ChampionDTO("Ivern", "test bio", "test icon");
        Assert.NotNull(championDto);
        Assert.Equal("test bio", championDto.Bio);
    }

    [Fact]
    public void Test_ContructeurDTOValideIcon()
    {
        ChampionDTO championDto = new ChampionDTO("Ivern", "test bio", "test icon");
        Assert.NotNull(championDto);
        Assert.Equal("test icon", championDto.Icon);
    }
        
    [Fact]
    public async Task Test_GetChampionAsync()
    {
        List<ChampionDTO> championsDto;
        IDataManager manager = new StubData();
        ChampionControllers control = new ChampionControllers(manager);
        OkObjectResult resultat = await control.GetChampions() as OkObjectResult;
        Assert.NotNull(resultat);
        IEnumerable<ChampionDTO> champions = resultat.Value as IEnumerable<ChampionDTO>;
        Assert.NotNull(champions);
        for (ChampionDTO champion : champions)
        {

        }

    }

    [Fact]
    public async void Test_PostChampionAsync()
    {
        
    }
}