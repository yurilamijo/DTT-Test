using AutoMapper;
using DTT_Test.Models;
using DTT_Test.Models.Users;
using DTT_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTT_Test.Data
{
    public class DbSeeder
    {
        private static IUserService _userService;

        public static void Initialize(DTTContext context)
        {
            _userService = new UserService(context);
            if (!context.Users.Any())
            {
                // Creates user
                _userService.Create(new User { 
                    FirstName = "Yuri", 
                    Username = "YuriLamijo", 
                    PasswordHash = null, 
                    PasswordSalt = null,
                    Role = Role.Admin 
                }, "DTT!Yuri");

                _userService.Create(new User
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
