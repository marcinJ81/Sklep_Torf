using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public interface IMethodDB_File_Memmory
    {
        IUserAccountAttributes iaccountAttributes { get; }
        ICheckAndAddUser icheckandadd { get; }
        IExternalId iexternalid { get; }
        ISearchUser isearch { get; }
    }
    public interface IUserAccountAttributes
    {
        bool AccountHaveBan(int id_user);
        bool AccountActive(int id_user);
        bool UserRegister(string name, string sname, string email);
    }

    public interface ICheckAndAddUser
    {
        bool CheckLoginAvaible_ToBase(string loginName);
        bool AddUser_ToBase(User user);
    }
    public interface IExternalId
    {
        bool ExternalIdSet(int id_ser);
    }
    public interface ISearchUser
    {
        User SearchUser_paramId(int id_user);
        List<User> InsertUserToFile(List<User> listOfUsers);
    }

    public class DBInMemory : ADBInMemory, IMethodDB_File_Memmory
    {
        public DBInMemory()
            : base()
        {
            this.iaccountAttributes = ;
            this.icheckandadd = ;
            this.iexternalid = ;
            this.isearch = ;
        }
        public IUserAccountAttributes iaccountAttributes { get; }
        public ICheckAndAddUser icheckandadd { get; }
        public IExternalId iexternalid { get; }
        public ISearchUser isearch { get; }
    }
    public class UserAccountAttributes : IUserAccountAttributes
    {
        public bool AccountActive(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool AccountHaveBan(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool UserRegister(string name, string sname, string email)
        {
            throw new NotImplementedException();
        }
    }
    public class CheckAndAddUser : ICheckAndAddUser
    {
        public bool AddUser_ToBase(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckLoginAvaible_ToBase(string loginName)
        {
            throw new NotImplementedException();
        }
    }
    public class ExternalId : IExternalId
    {
        public bool ExternalIdSet(int id_ser)
        {
            throw new NotImplementedException();
        }
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
    public abstract class ADBInMemory
    {
        protected IQuerySqlite testDataBase;
        public string createTable { get; }
        public string selectUserTable { get; }
        public ADBInMemory()
        {
            this.createTable = @"CREATE TABLE IF NOT EXISTS user_register
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
        protected string getInsertQuery(User user)
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
