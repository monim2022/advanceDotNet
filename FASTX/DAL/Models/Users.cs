using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]

        public string Type { get; set; }

    }
}
