using System;
using System.Collections.Generic;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : AQueryDefinition, IUsersRepository
    {
        private DataBaseType dbType;
        public UsersRepository(TableName tableName, DataBaseType choice)
        :base(tableName,choice)
        {
            this.dbType = choice;
        }
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

        public bool IsThereAUserRegister(string name, string sname,string email)
        {
            throw new NotImplementedException();
        }

        public User SearchUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsLoginNameFree(string loginName)
        {
           return CheckLoginAvaible_ToBase(loginName);
        }
    }
}
