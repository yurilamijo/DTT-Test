using DTT_Test.Models;
using DTT_Test.Repositories;
using System.Linq;

namespace DTT_Test.Data
{
    public class DbSeeder
    {
        private static IUserRepository _userRepository;

        public static void Initialize(DTTContext context)
        {
            _userRepository = new UserRepository(context);
            if (!context.Users.Any())
            {
                // Creates user
                _userRepository.Create(new User { 
                    FirstName = "Yuri", 
                    Username = "YuriLamijo", 
                    PasswordHash = null, 
                    PasswordSalt = null,
                    Role = Role.Admin 
                }, "DTT!Yuri");

                _userRepository.Create(new User
                {
                    FirstName = "CMSuser",
                    Username = "CMSuser",
                    PasswordHash = null,
                    PasswordSalt = null,
                    Role = Role.User
                }, "DTT!User");
            }
        }
    }
}
