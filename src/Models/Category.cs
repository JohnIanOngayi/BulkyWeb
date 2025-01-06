using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    required public string Name { get; set; }
    public int DisplayOrder { get; set; }
}
