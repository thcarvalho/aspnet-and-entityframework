using System.ComponentModel.DataAnnotations;

namespace asptest.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Required Field")]
        [MaxLength(60, ErrorMessage = "This field must be less than 60 caracters")]
        [MinLength(3, ErrorMessage = "This field must be more than 3 caracters")]
        public string Title { get; set; }
    }
}