using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BulkyWebRazorPages.Models;

public class NewCategory
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [DisplayName("Display Name")]
    [Range(1,100)]
    public int DisplayOrder { get; set; }
}