using API_lol.Controllers;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using StubLib;

namespace TestApiRest;

public class TestChampionController
{
    private readonly ILogger<ChampionController> _logger;

    [Fact]
    public void Test_ContructeurDTOValideName()
    {
        ChampionDTO championDto = new ChampionDTO(1, "Ivern", "test bio", "test class", "test icon", "test image");
        Assert.NotNull(championDto);
        Assert.Equal("Ivern", championDto.Name);
    }

    [Fact]
    public void Test_ContructeurDTOValideBio()
    {
        ChampionDTO championDto = new ChampionDTO(1,"Ivern", "test bio", "test class", "test icon", "test image");
        Assert.NotNull(championDto);
        Assert.Equal("test bio", championDto.Bio);
    }

    [Fact]
    public void Test_ContructeurDTOValideIcon()
    {
        ChampionDTO championDto = new ChampionDTO(1,"Ivern", "test bio", "test class", "test icon", "test image");
        Assert.NotNull(championDto);
        Assert.Equal("test icon", championDto.Icon);
    }

    [Fact]
    public async void Test_GetChampion_ReturnOkResult()
    {
        // Arrange 
        var  championController = new ChampionController(new StubData(), _logger);
        
        // Act 
        var championsResult = await championController.GetChampions();
        var objectResult = championsResult as OkObjectResult; // renvoie null si le code retour n'est pas 200

        // Assert 
        Assert.NotNull(objectResult);
        Assert.Equal(championsResult, objectResult);
    }
    
    [Fact]
    public async void Test_GetChampion_ReturnAllChampions()
    {
        // Arrange 
        var  championController = new ChampionController(new StubData(), _logger);
        
        // Act 
        var championsResult = await championController.GetChampions();
        var objectResult = championsResult as OkObjectResult;
        var pageDto = objectResult?.Value as PageDTO<IEnumerable<ChampionDTO>>;

        // Assert 
        Assert.NotNull(objectResult);
        Assert.NotNull(pageDto);
        Assert.Equal(6,pageDto.Data.Count());
        
    }
    
    /*[Fact]
    public async void Test_GetChampionReturnNotFoundResult()
    {
        //Arrange 
        var championController = new ChampionController(new StubData(), _logger);
        
        // Act
        var championsResult = await championController.GetChampions();
        var objectResult = championsResult as NotFoundResult;
 
        //Assert
        Assert.NotNull(objectResult);
        
    }

    [Fact]
    public async void Test_GetChampionById_ReturnTheChampion()
    {
        // Arrange 
        var  championController = new ChampionController(new StubData(), _logger);
        int expeptedId = 1;
        var expectedChampion = new ChampionDTO(1, "Akali", null, null, null, null);
        
        // Act 
        var championResult = await championController.GetChampionById(expeptedId);
        var objectResult = championResult as OkObjectResult;
        var champion = objectResult.Value as ChampionDTO;

        // Assert 
        Assert.NotNull(objectResult);
        Assert.NotNull(champion);
        Assert.Equal(champion, expectedChampion);
    }
    
    [Fact]
    public async void Test_GetChampionById_ReturnOkResult()
    {
        // Arrange 
        var  championController = new ChampionController(new StubData(), _logger);
        int expeptedId = 1;
        
        // Act 
        var championResult = await championController.GetChampionById(expeptedId);
        var objectResult = championResult as OkObjectResult;

        // Assert 
        Assert.NotNull(objectResult);
        Assert.Equal(championResult, objectResult);
        
    }

    [Fact]
    public async void Test_GetChampionByIdReturnNotFoundResult()
    {
        //Arrange 
        var championController = new ChampionControllers(new StubData(), _logger);
        int expeptedId = 999999999;
        
        // Act
        var championResult = await championController.GetChampionById(expeptedId);
        var objectResult = championResult as NotFoundResult;
 
        //Assert
        Assert.IsType<NotFoundResult>(objectResult);
        
    }
    [Fact]
    public async void Test_AddChampionReturnOkResult()
    {
        
        // Arrange 
        var  championController = new ChampionController(new StubData(), _logger);
        var championDTO = new ChampionDTO(10, "Name","Biographie", "Classe","Icone", "Image");
        
        // Act
        var championResult = await championController.AddChampion(championDTO);
        var objectResult = championResult as OkObjectResult;
        
        // Assert
        Assert.NotNull(objectResult);
        Assert.Equal(championResult, objectResult);
    }
    
    [Fact]
    public async void Test_AddChampionReturnNotFoundResult()
    {
        
        // Arrange 
        var  championController = new ChampionControllers(new StubData(), _logger);
        var championDTO = new ChampionDTO(10, "Biographie", "Icone", "Nom");
        
        // Act
        var championResult = await championController.AddChampion(championDTO);
        var objectResult = championResult as NotFoundResult;
        
        // Assert
        Assert.NotNull(objectResult);
        Assert.Equal(championResult, objectResult);
    }
    
    [Fact]
    public async void Test_AddChampionReturnAllChampion()
    {
        
        // Arrange 
        var  championController = new ChampionControllers(new StubData(), _logger);
        var championDTO = new ChampionDTO(10, "Biographie", "Icone", "Nom");
        
        // Act
        await championController.AddChampion(championDTO);
        var result = await championController.GetChampionById(championDTO.Id);
        // Assert
        var createdResult = Assert.IsType<ObjectResult >(result); // ObjectResult contient 201 si le champion a bien été créé et les infos sur le champions
        var championResultDto = Assert.IsType<ChampionDTO>(createdResult.Value); // permet de recuperer le champion ( = valeur de la variable createdResult)
        Assert.NotNull(result);
        Assert.NotNull(createdResult);
        Assert.NotNull(championResultDto);
        Assert.Equal(championResultDto.Id, championDTO.Id);
        Assert.Equal(championResultDto.Name, championDTO.Name);
        Assert.Equal(championResultDto.Bio, championDTO.Bio);
        Assert.Equal(championResultDto.Icon, championDTO.Icon);
    }
    
    [Fact]
    public async void Test_DeleteChampionReturnNotFoundResult()
    {
        
        // Arrange 
        var  championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;        
        // Act
        var championResult = await championController.DeleteChampion(expectedId);
        var objectResult = championResult as NotFoundResult;
        
        // Assert
        Assert.NotNull(objectResult);
        Assert.Equal(championResult, objectResult);
    }
    
    [Fact]
    public async void Test_DeleteChampionReturnOkResult()
    {
        
        // Arrange 
        var  championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;        
        // Act
        var championResult = await championController.DeleteChampion(expectedId);
        var objectResult = championResult as OkObjectResult;
        
        // Assert
        Assert.NotNull(objectResult);
        Assert.Equal(championResult, objectResult);
    }
    
    [Fact]
    public async void Test_DeleteChampionNotReturnChampionMatchinWithId()
    {
        
        // Arrange 
        var  championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;        
        // Act
        var championResult = await championController.DeleteChampion(expectedId);
        var result = await championController.GetChampionById(expectedId);
        var objectResult = result as NotFoundResult;

        // Assert
        Assert.NotNull(championResult);
        Assert.NotNull(result);
        Assert.Equal(result, objectResult);
    }
    
    [Fact]
    public async void Test_DeleteChampionReturnAllChampionsWithoutChampionMatchinWithId()
    {
        // Arrange 
        var  championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;  
        ChampionDTO championDto = new ChampionDTO(1,"Ivern", "test bio", "test icon");
        List<ChampionDTO> champions = new()
        {
            new ChampionDTO(2, "Aatrox", null, null),
            new ChampionDTO(3, "Ahri", null, null),
            new ChampionDTO(4, "Akshan", null, null),
            new ChampionDTO(5, "Bard", null, null),
            new ChampionDTO(6, "Alistar", null, null)
        };

        // Act
        var championResult = await championController.DeleteChampion(expectedId);
        var allChampions = await championController.GetChampions();

        // Assert
        var createdResult = Assert.IsType<ObjectResult >(allChampions);
        var listchampionsResultDto = Assert.IsType<List<ChampionDTO>>(createdResult.Value); 

        Assert.NotNull(championResult);
        Assert.NotNull(allChampions);
        Assert.Equal(listchampionsResultDto, champions);
    }

    [Fact]
    public async void Test_ModifyNameChampionReturnOkResult()
    {
        // Arrange
        var championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;
        string newName = "Akala";
        
        // Act 
        var result = await championController.ModifyNameChampion(expectedId, newName);
        var objectResult = result as OkObjectResult;
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(result,objectResult);
    }
    
    [Fact]
    public async void Test_ModifyNameChampionReturnNotFoundResult()
    {
        // Arrange
        var championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;
        string newName = "Akala";
        
        // Act 
        var result = await championController.ModifyNameChampion(expectedId, newName);
        var objectResult = result as NotFoundResult;
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(result,objectResult);
    }
    
    [Fact]
    public async void Test_ModifyNameChampionReturnChampionWithNewName()
    {
        // Arrange
        var championController = new ChampionControllers(new StubData(), _logger);
        int expectedId = 1;
        string newName = "Akala";

        ChampionDTO champion = new ChampionDTO(1, newName, null, null);
        
        // Act 
        var result = await championController.ModifyNameChampion(expectedId, newName);
        var championId = await championController.GetChampionById(expectedId);
        
        // Façon 1 de faire pour récupérer le résultat
        var objectResult = championId as OkObjectResult;
        var newResult = objectResult.Value as ChampionDTO;
        
        // Façon 2 de faire pour récupérer le résultat
        var createdResult = Assert.IsType<ObjectResult >(result);
        var listchampionsResultDto = Assert.IsType<ChampionDTO>(createdResult.Value); 
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(newResult, champion);
        Assert.Equal(listchampionsResultDto,champion);
    }
    */
}