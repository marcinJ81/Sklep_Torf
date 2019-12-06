﻿using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class AQueryDefinition
    {
        protected IQuerySqlite testDataBase;
        public string createTable { get; }
        public string selectUserTable { get; }
        public string dropTable { get; }

        private AQueryDefinition(DataBaseType choise)
        {
            if ((int)choise == 0)
            {
                this.testDataBase = new TestDataBase_InMemmory();
            }
            if ((int)choise == 1)
            {
                this.testDataBase = new TestDataBase_InFile();
            }
        }
        public AQueryDefinition(TableName tableName, DataBaseType choise) :
            this(choise)
        {
            if ((int)tableName == 1)
            {
                if ((int)choise == 1)
                    dropTable = @"DROP TABLE IF EXISTS; ";
                else
                    dropTable = string.Empty;

                this.createTable =dropTable + @"CREATE TABLE IF NOT EXISTS user_register
                (
                    user_id INTEGER IDENTITY PRIMARY KEY,
                    user_name VARCHAR NOT NULL,
                    user_sname VARCHAR NOT NULL,
                    user_login VARCHAR UNIQUE,
                    user_email VARCHAR NOT NULL,
                    user_account_active INT NOT NULL,
                    user_ban BIT NOT NULL,
                    external_id VARCHAR NOT NULL
                );";
                this.selectUserTable = @"select user_id, user_name,user_sname," +
                                       "user_login,user_email, user_account_active " +
                                       " user_ban, external_id from user_register";
            }
            

        }
        private string getInsertQuery(User user)
        {
            string insertQuery = @"insert into user_register values"
                                + "(" + user.user_id.ToString() + ",'" + user.user_name + "','" + user.user_sname + "','"
                                + user.user_login + "','" + user.user_email + "'," + user.user_account_active.ToString()
                                + "," + user.user_ban + "," + "'" + user.external_id + "'" + ")";
            return insertQuery;
        }
        public bool AddUser_ToBase(User user)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTable);
            queryDictionary.Add("Insert", getInsertQuery(user));
            queryDictionary.Add("Select", selectUserTable);
            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);

            User userdb = new User();
            string[] source = result[1].Split(new char[] { ',' });
            userdb.user_id = int.Parse(source[0]);
            userdb.user_name = source[1];
            userdb.user_sname = source[2];
            userdb.user_login = source[3];
            userdb.user_email = source[4];
            userdb.user_account_active = int.Parse(source[5]);

            if ((userdb.user_name == user.user_name) && (userdb.user_email == user.user_email))
                return true;
            return false;
        }

    }
}
