using System;
using System.Collections.Generic;
using System.Linq;
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
        private DataBaseType dbType;

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
            this.dbType = choise;
        }
        public AQueryDefinition(TableName tableName, DataBaseType choise) :
            this(choise)
        {
            if ((int)tableName == 1)
            {
                if ((int)choise == 1)
                    dropTable = @"DROP TABLE IF EXISTS user_register; ";
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

            string[] source;
            if ((int)dbType == 0)
            {
                User userdb = new User();
                source = result[1].Split(new char[] { ',' });
                userdb.user_id = int.Parse(source[0]);
                userdb.user_name = source[1];
                userdb.user_sname = source[2];
                userdb.user_login = source[3];
                userdb.user_email = source[4];
                userdb.user_account_active = int.Parse(source[5]);
                userdb.external_id = source[6];
                if ((userdb.user_name == user.user_name) && (userdb.user_email == user.user_email))
                    return true;
                return false;
            }
            else
            {
                List<User> listUser = GetAllUsers();
                if ((listUser.Any(x => x.user_name == user.user_name)) && (listUser.Any(x => x.user_login == user.user_login)))
                    return true;
                return false;
            } 
        }
        public bool AccountHaveBan(int id_user)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_ban == true))
                return false;
            return true;
        }
        public bool AccountActive(int id_user)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_account_active == 1))
                return true;
            return false;
        }
        public bool ExternalIdSet(int id_ser)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => String.IsNullOrEmpty(x.external_id)))
                return true;
            return false;
        }
        public bool CheckLoginAvaible_ToBase(string loginName)
        {
          List<User> result = GetAllUsers();
          if (result.Any(x => x.user_login == loginName))
                return false;
            return true;
        }
        public bool UserRegister(string name, string sname, string email)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_name == name && x.user_sname == sname && x.user_email == email))
                return true;
            return false;
        }
        public User SearchUser_paramId(int id_user)
        {
            List<User> result = GetAllUsers();
            var source = result.Where(x => x.user_id == id_user).First();
            return source;
        }
        public List<User> InsertUserToFile(List<User> listOfUsers)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();

            foreach (var i in listOfUsers)
            {
                queryDictionary.Add("Insert", getInsertQuery(i));
                var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            }
            return GetAllUsers();
        }
        private List<User> GetAllUsers()
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Select", selectUserTable);
            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);

            int amountRows = result.Count;
            string[] source;
            List<User> listUser = new List<User>();
            if (amountRows > 1)
            {
                for (int i = 1; i < amountRows; i++)
                {
                    source = result[i].Split(new char[] { ',' });
                    listUser.Add(new User
                    {
                        user_id = int.Parse(source[0]),
                        user_name = source[1],
                        user_sname = source[2],
                        user_login = source[3],
                        user_email = source[4],
                        user_account_active = int.Parse(source[5]),
                        external_id = source[6]
                    });
                }
                return listUser;
            }
            listUser.Add(new User
            {
                user_id = -1,
                user_name = "brak",
                user_sname = "brak",
                user_account_active = 0,
                user_ban = true,
                user_email = "brak",
                user_login = "brak",
                external_id = "brak"
            });
            return listUser;
        }


    }
}
