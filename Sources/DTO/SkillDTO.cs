namespace DTO;

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