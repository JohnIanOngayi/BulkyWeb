using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
}
