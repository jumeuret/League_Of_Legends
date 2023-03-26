namespace DTO;

/// <summary>
/// Classe correspondant à une Rune, elle sert à transférer des données entre l'API et l'application cliente
/// Elle permet de limiter les données échangées en ne renvoyant que les informations utiles au client
/// </summary>
public class RuneDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Family { get; set; }
    public string Icon { get; set; }
    public string Image { get; set; }
    public string Categorie { get; set; }
    public ICollection<RunePageDTO> RunePages { get; set; } = new List<RunePageDTO>();

    public RuneDTO(int id, string name, string description, string family, string icon, string image, string categorie)
    {
        Id = id;
        Name = name;
        Description = description;
        Family = family;
        Icon = icon;
        Image = image;
        Categorie = categorie;
    }
}