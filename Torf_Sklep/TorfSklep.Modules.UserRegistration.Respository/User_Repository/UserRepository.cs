using System;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : IUsersRepository
    {
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountActive(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountHaveBan(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsExternalIDSet(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsThereAUserExist(int id_user)
        {
            throw new NotImplementedException();
        }

        public User SearchUser(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
