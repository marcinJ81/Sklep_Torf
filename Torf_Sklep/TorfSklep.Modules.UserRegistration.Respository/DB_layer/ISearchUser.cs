using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface ISearchUser
    {
        User SearchUser_paramId(int id_user);
        List<User> InsertUserToFile(List<User> listOfUsers);
    }
    public class SearchUser : ISearchUser
    {
        public List<User> InsertUserToFile(List<User> listOfUsers)
        {
            throw new NotImplementedException();
        }

        public User SearchUser_paramId(int id_user)
        {
            throw new NotImplementedException();
        }
    }
}
