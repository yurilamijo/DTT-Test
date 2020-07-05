using System.ComponentModel.DataAnnotations;

namespace DTT_Test.Models.Users
{
    public class UpdateModel
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]\D*$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}