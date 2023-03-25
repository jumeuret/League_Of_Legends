using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework
{
    [Table("RunePage")]
    public class RunePageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RuneEntity> Runes { get; set; } = new List<RuneEntity>();
    }
}
