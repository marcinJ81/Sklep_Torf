﻿using System;
using System.Collections.Generic;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : AQueryDefinition, IUsersRepository
    {
        public UsersRepository(TableName tableName)
        :base(tableName)
        {
        }
        public bool AddUser(User user)
        {
            if (AddUser_InMemmoryBase(user))
                return true;
            return false;
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountActive(int id_user)
        {
            if (IsAccountActive_whenIdIsOne(id_user))
                return true;
            return false;
        }

        public bool IsAccountHaveBan(int id_user)
        {
            if (IsAccountHaveBan_whenIdIsNotOne(id_user))
                return true;
            return false;
        }

        public bool IsExternalIDSet(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsThereAUserExist(string name, string sname, string email)
        {
            if (base.IsThereAUserExist_InMemmory(name, sname, email))
                return true;
            return false;
        }

        public User SearchUser(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
