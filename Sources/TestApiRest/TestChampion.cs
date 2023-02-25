using API_lol.Controllers;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Model;
using StubLib;

namespace TestApiRest;

public class UnitTest1
{
    private ChampionControllers championController = new ChampionControllers(new StubData());
    
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
    public async void Test_GetChampion()
    {
        var championsResult = await championController.Get();
        var objectResult = championsResult as OkObjectResult;
        Assert.NotNull(objectResult);
        var champions = objectResult?.Value as IEnumerable<ChampionDTO>;
        Assert.NotNull(champions);
        Assert.Equal(championsResult, objectResult);
        
    }
    
    [Fact]
    public async void Test_PostChampion()
    {
        var championDTO = new ChampionDTO("Biographie", "Icone", "Nom");

        /*var championResult = await championController.Post(championDTO);

        var createdResult = championResult as CreatedAtActionResult;
        Assert.NotNull(createdResult);
        var chamion = createdResult.Value as ChampionDTO;
        Assert.NotNull(chamion);*/
    }
}