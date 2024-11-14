using System.ComponentModel.DataAnnotations;

namespace AAASecurity.Models
{
    public class BadPassword
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
