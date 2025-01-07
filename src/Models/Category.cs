using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace src.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public required string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "The Display Order must be in the range 1 to 100")]
    public int DisplayOrder { get; set; }
}
