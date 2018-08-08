
using AgressoDirectory.DataAccess;

namespace AgressoDirectory.BusinessLogic
{
    public class UserManager
    {
        public bool Login(string userName, string password)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.Login(userName, password);
        }
        public bool Forget(string userName, string password)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.Forget(userName, password);
        }
    }
}
