using DTT_Test.Helpers;
using DTT_Test.Models;
using System;
using System.Linq;

namespace DTT_Test.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DTTContext _context;

        public UserRepository(DTTContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            // Checks if parameters are not empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;

            // Gets the user if exist else it will send a default value
            var user = _context.Users.SingleOrDefault(u => u.Username.Equals(username));

            // Checks if user exists
            if (user == null) return null;

            // Checks if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
        }

        public User Create(User user, string password)
        {
            // Validates password
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is requred");

            // Checks if username already exists
            if (_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            // Creates a hashed password
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // Sets the password
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Saves user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            // Checks if user exists
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User userParam, string password = null)
        {
            // Finds user by id
            var user = _context.Users.Find(userParam.Id);

            // Checks if user exists
            if (user == null) 
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // Checks if firstname is provided and updates it
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            // Checks if password is provided and updates it
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                // Creates a hashed password
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                // Sets the password
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // Validates password
            if (password == null) 
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) 
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            // Hashing the password
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            // Validates password
            if (password == null) 
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) 
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) 
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) 
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                // Hashing the input password
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    // Compares DbPassword with the password from the input
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
