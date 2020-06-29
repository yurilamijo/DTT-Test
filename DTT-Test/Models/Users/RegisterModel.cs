using System.ComponentModel.DataAnnotations;

namespace DTT_Test.Models.Users
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Password { get; set; }
    }
}