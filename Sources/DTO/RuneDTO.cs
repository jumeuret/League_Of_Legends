namespace DTO;

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