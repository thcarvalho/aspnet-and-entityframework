using System.ComponentModel.DataAnnotations;

namespace asptest.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required Field")]
    [MinLength(3, ErrorMessage = "This field must have more than 3 caracters")]
    [MaxLength(60, ErrorMessage = "This field must have less than 60 caracters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Required Field")]
    [MinLength(6, ErrorMessage = "This field must have more than 6 caracters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Required Field")]
    [MinLength(2, ErrorMessage = "This field must have more than 2 caracters")]
    [MaxLength(30, ErrorMessage = "This field must have less than 30 caracters")]
    public string Role { get; set; }
  }
}