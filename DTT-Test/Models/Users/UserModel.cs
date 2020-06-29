using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTT_Test.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int Role { get; set; }
        public int UserName { get; set; }
    }
}
