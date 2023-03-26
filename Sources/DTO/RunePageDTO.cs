namespace DTO;

/// <summary>
/// Classe correspondant à une RunePage, elle sert à transférer des données entre l'API et l'application cliente
/// Elle permet de limiter les données échangées en ne renvoyant que les informations utiles au client
/// </summary>
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