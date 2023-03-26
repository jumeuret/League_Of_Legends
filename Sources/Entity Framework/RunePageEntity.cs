using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework
{
    /// <summary>
    /// Classe correspondant à une entité runePage
    /// </summary>
    [Table("RunePage")]
    public class RunePageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RuneEntity> Runes { get; set; } = new List<RuneEntity>();
    }
}
