namespace DTO;

/// <summary>
/// Classe correspondant à un Skill, elle sert à transférer des données entre l'API et l'application cliente
/// Elle permet de limiter les données échangées en ne renvoyant que les informations utiles au client
/// </summary>
public class SkillDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public SkillDTO(string Name, string Description, string Type)
    {
        this.Name = Name;
        this.Description = Description;
        this.Type = Type;
    }
}