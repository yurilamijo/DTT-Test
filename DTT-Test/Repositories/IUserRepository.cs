using DTT_Test.Models;

namespace DTT_Test.Repositories
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
