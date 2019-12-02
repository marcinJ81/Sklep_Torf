﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class AQueryDefinition
    {
        public string createTable { get; }
        public string selectUserTable { get; }
        public AQueryDefinition(TableName tableName)
        {
            if ((int)tableName == 1)
            {
                    this.createTable = @"CREATE TABLE user_register
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
            }

        }
    }
}
