using System;
using System.Collections.Generic;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : AQueryDefinition, IUsersRepository, IUserRepository_insert
    {
        public UsersRepository(DataBaseType choice)
        :base(choice){}
        public bool AddUser(User user)
        {
            if (imethodDB.AddUser_ToBase(user))
                return true;
            return false;
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountActive(int id_user)
        {
            if (imethodDB.AccountActive(id_user))
                return true;
            return false;
        }

        public bool IsAccountHaveBan(int id_user)
        {
            if (imethodDB.AccountActive(id_user))
                return true;
            return false;
        }

        public bool IsExternalIDSet(int id_user)
        {
            if (imethodDB.ExternalIdSet(id_user))
                return true;
            return false;
        }

        public bool IsThereAUserRegister(string name, string sname,string email)
        {
            if(imethodDB.UserRegister(name,sname,email))
                return true;
            return false;
        }

        public User SearchUser(int user_id)
        {
            return imethodDB.SearchUser_paramId(user_id);
        }

        public bool IsLoginNameFree(string loginName)
        {
           return imethodDB.CheckLoginAvaible_ToBase(loginName);
        }

        public List<User> insertUsers(List<User> listUsers)
        {
            return imethodDB.InsertUserToFile(listUsers);
        }
    }
}
