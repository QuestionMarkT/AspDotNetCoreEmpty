using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreEmpty.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Display(Name = "Name")]
    public string CategoryName { get; set; } = string.Empty;
    [Required, Display(Name = "Description")]
    public string? Description { get; set; }
    public DateTime? DateAdded { get; set; }
    public List<Pie>? Pies { get; set; }
    
}
