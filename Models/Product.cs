using System.ComponentModel.DataAnnotations;

namespace asptest.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required Field")]
    [MaxLength(60, ErrorMessage = "This field must have less than 60 caracters")]
    [MinLength(3, ErrorMessage = "This field must have more than 3 caracters")]
    public string Title { get; set; }

    [MaxLength(1024, ErrorMessage = "This field must have less than 1024 caracters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Required Field")]
    [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Category not defined")]
    [Required(ErrorMessage = "Required Field")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
  }
}