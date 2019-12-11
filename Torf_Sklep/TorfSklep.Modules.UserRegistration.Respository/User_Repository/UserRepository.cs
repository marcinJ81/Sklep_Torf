using System;
using System.Collections.Generic;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : AQueryDefinition, IUsersRepository
    {
        public UsersRepository(TableName tableName, DataBaseType choice)
        :base(tableName,choice)
        {}
        public bool AddUser(User user)
        {
            if (AddUser_ToBase(user))
                return true;
            return false;
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountActive(int id_user)
        {
            if (AccountActive(id_user))
                return true;
            return false;
        }

        public bool IsAccountHaveBan(int id_user)
        {
            if (AccountActive(id_user))
                return true;
            return false;
        }

        public bool IsExternalIDSet(int id_user)
        {
            if (ExternalIdSet(id_user))
                return true;
            return false;
        }

        public bool IsThereAUserRegister(string name, string sname,string email)
        {
            if(UserRegister(name,sname,email))
                return true;
            return false;
        }

        public User SearchUser(int user_id)
        {
            return SearchUser_paramId(user_id);
        }

        public bool IsLoginNameFree(string loginName)
        {
           return CheckLoginAvaible_ToBase(loginName);
        }
    }
}
