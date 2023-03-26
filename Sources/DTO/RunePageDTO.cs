namespace DTO;

public class RunePageDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<RuneDTO> Runes { get; set; } = new List<RuneDTO>();

    public RunePageDTO(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public void addRune(RuneDTO runeDTO)
    {
        Runes.Add(runeDTO);        
    }
}