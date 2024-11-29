using System.ComponentModel.DataAnnotations;

namespace RazorPageHW.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(8)]
        [MaxLength(64)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

        

    }
}
