using DTT_Test.Models;
using DTT_Test.Repositories;
using System.Linq;

namespace DTT_Test.Data
{
    /* Database seeder thats inserts a new users */
    public class DbSeeder
    {
        private static IUserRepository _userRepository;

        public static void Initialize(DTTContext context)
        {
            _userRepository = new UserRepository(context);
            
            // Checks if there are no records of users in the User table in the database
            if (!context.Users.Any())
            {
                // Creates a Admin user
                _userRepository.Create(new User { 
                    FirstName = "Yuri", 
                    Username = "YuriLamijo", 
                    PasswordHash = null, 
                    PasswordSalt = null,
                    Role = Role.Admin 
                }, "DTT!Yuri");

                // Creates a CMS user
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
