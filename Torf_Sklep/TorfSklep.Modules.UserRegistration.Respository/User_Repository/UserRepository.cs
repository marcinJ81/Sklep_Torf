﻿using System;
using System.Collections.Generic;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : AQueryDefinition, IUsersRepository
    {
        private IQuerySqlite testDataBase;
        public UsersRepository(TableName tableName)
        :base(tableName)
        {
            this.testDataBase = new TestDataBase();
        }
        public bool AddUser(User user)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTable);
            queryDictionary.Add("Insert", getInsertQuery(user));
            queryDictionary.Add("Select", selectUserTable);

            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            if (result.Count == 2)
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
