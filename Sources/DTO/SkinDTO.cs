using Model;

namespace DTO;

public class SkinDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Champion Champion { get; set; }
    
    public float Price { get; set; }
    
    public string Icon { get; set; }
    
    public string Image { get; set; }
    public string Description { get; set; }

    public SkinDTO(int Id, string Name, Champion Champion, float Price = 0.0f, string Icon = "", string Image = "", string Description = "")
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Price = Price;
        this.Image = Image;
        this.Icon = Icon;
        this.Champion = Champion;
    }
}