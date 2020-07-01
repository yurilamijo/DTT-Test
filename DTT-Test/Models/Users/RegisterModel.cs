using System.ComponentModel.DataAnnotations;

namespace DTT_Test.Models.Users
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]\D*$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Role { get; set; }

        [Required]
        public string Password { get; set; }
    }
}