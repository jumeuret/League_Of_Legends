using API_lol.Mapper;
using DTO;
using Model;
using Xunit;

namespace TestDTO;

public class TestRunePagetDT0
{

    [Theory]
    [InlineData(0, "Je suis le nom de runePage1")]
    [InlineData(0, "Je suis le nom de runePage2")]
    public void Test_RunePageToDTO(int id, string nom)
    {
        RunePage runePage = new RunePage(nom);
        RunePageDTO objectDto = runePage.ToDTO();

        var runePageDto = objectDto as RunePageDTO;
        Assert.NotNull(runePageDto);
        
        Assert.Equal(id, runePageDto.Id);
        Assert.Equal(nom, runePageDto.Name);
    }
}