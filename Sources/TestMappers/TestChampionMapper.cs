using System;
using API_lol.Mapper;
using DTO;
using Model;
using Xunit;

namespace TestMappers
{
    public class TestChampionMapper
    {
        [Theory]
        [InlineData(0, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Tank")]
        [InlineData(0, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Unknown")]
        public void TestToDTO(int id, string nom, string bio, string icone, string image, string classe)
        {
            var championModel = new Champion(nom, (ChampionClass)Enum.Parse(typeof(ChampionClass), classe), icone, image, bio);
            var championDTO = championModel.ToDTO() as ChampionDTO;
            
            Assert.NotNull(championDTO);
            Assert.Equal(id, championDTO.Id);
            Assert.Equal(nom, championDTO.Name);
            Assert.Equal(bio, championDTO.Bio);
            Assert.Equal(icone, championDTO.Icon);
            //Assert.Equal(image, championDTO.Image);
            Assert.Equal(classe, championDTO.Class);
        }
        
        [Theory]
        [InlineData(0, "Test1", "Je suis la bio du test1", "Je suis l_icone du test1", "Je suis l_image du test1", "Tank")]
        [InlineData(0, "Test2", "Je suis la bio du test2", "Je suis l_icone du test2", "Je suis l_image du test2", "Unknown")]
        public void TestFromDTO(int id, string nom, string bio, string icone, string image, string classe)
        {
            var championDTO = new ChampionDTO(id, nom,  bio, classe, icone, image);
            var championModel = championDTO.FromDTO() as Champion;
            
            Assert.NotNull(championModel);
            //Assert.Equal(id, championModel.Id);
            Assert.Equal(nom, championModel.Name);
            Assert.Equal(bio, championModel.Bio);
            Assert.Equal(icone, championModel.Icon);
            //Assert.Equal(image, championModel.Image.ToString());
            Assert.Equal(classe, championModel.Class.ToString());
        }
    }
}