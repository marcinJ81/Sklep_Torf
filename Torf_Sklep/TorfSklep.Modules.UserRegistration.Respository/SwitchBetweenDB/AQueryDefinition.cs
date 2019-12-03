﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class AQueryDefinition
    {
        private IQuerySqlite testDataBase;
        public string createTableUser { get; }
        public string selectUserTable { get; }
        public string deleteUserRow { get; }

        public string createTableListAccount { get; }
        public string selectListAccountTable { get; }
        private AQueryDefinition()
        {
            this.testDataBase = new TestDataBase();
        }
        public AQueryDefinition(TableName tableName):
            this()
        {
            if ((int)tableName == 1)
            {
                    this.createTableUser = @"CREATE TABLE user_register
                (
                    user_id INTEGER IDENTITY PRIMARY KEY,
                    user_name VARCHAR NOT NULL,
                    user_sname VARCHAR NOT NULL,
                    user_login VARCHAR UNIQUE,
                    user_email VARCHAR NOT NULL,
                    user_account_active INT NOT NULL,
                    user_ban BIT NOT NULL,
                    external_id VARCHAR UNIQUE
                );";
                this.selectUserTable = @"select user_id, user_name,user_sname," +
                                       "user_login,user_email, user_account_active " +
                                       " user_ban, external_id from user_register";
                this.deleteUserRow = @"delete user_regiter where user_id = 1";
            }
            if((int)tableName == 2)
            {
                this.createTableListAccount = @"CREATE TABLE user_account_to_verification
                (
                    account_id INTEGER IDENTITY PRIMARY KEY,
                    user_id int NULL,
                    request_id int NULL,
                );";
                this.selectListAccountTable = @"select account_id,user_id,request_id from user_account_to_verification";
            }

        }
        private string getInsertQueryUser(User user)
        {
            string insertQuery = @"insert into user_register values"
                                + "(" + user.user_id.ToString() + ",'" + user.user_name + "','" + user.user_sname + "','"
                                + user.user_login + "','" + user.user_email + "'," + user.user_account_active.ToString()
                                + "," + user.user_ban + "," + "'" + user.external_id + "'" + ")";
            return insertQuery;
        }
        public bool AddUser_InMemmoryBase(User user)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTableUser);
            queryDictionary.Add("Insert", getInsertQueryUser(user));
            queryDictionary.Add("Select", selectUserTable);

            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            if (result.Count == 2)
                return true;
            return false;
        }

        public bool IsAccountActive_whenIdIsOne(int id_user)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTableUser);
            queryDictionary.Add("Insert", getInsertQueryUser(new User()
            {
                user_id = 1,user_name = "test_name_user"
            }));
            queryDictionary.Add("Select", selectUserTable);
            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            if (result.Any(x => x.Contains(id_user.ToString())))
                return true;
            return false;
        }

        public bool IsAccountHaveBan_whenIdIsNotOne(int id_user)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTableUser);
            queryDictionary.Add("Insert", getInsertQueryUser(new User()
            {
                user_id = 1,
                user_name = "test_name_user",
                user_ban = false
            }));
            queryDictionary.Add("Select", selectUserTable);
            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            if (result.Any(x => x.Contains("false")))
                return true;
            return false;
        }

        public bool DeleteUser_whenIdIsOne(int id_user)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTableUser);
            queryDictionary.Add("Insert", getInsertQueryUser(new User()
            {
                user_id = 1,
                user_name = "test_name_user",
                user_ban = false
            }));
            queryDictionary.Add("Select", selectUserTable);
            queryDictionary.Add("Delete", deleteUserRow);
            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            if (result.Count == 1)
                return true;
            return false;
        }

    }
}