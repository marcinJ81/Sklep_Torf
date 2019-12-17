using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface IAddUser
    {
        bool AddUser_ToBase(User user);
        List<User> InsertOneOrMoreUsers(List<User> listOfUsers);
    }

    public class AdditionUser : ADBInMemory, IAddUser
    {
        private readonly ISearchUser searchUser;
        public AdditionUser(ISearchUser searchUser)
        {
            this.searchUser = searchUser;
        }
        public List<User> InsertOneOrMoreUsers(List<User> listOfUsers)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();

            foreach (var i in listOfUsers)
            {
                queryDictionary.Add("Create", createTable);
                queryDictionary.Add("Insert", getInsertQuery(i));
                var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(queryDictionary);
            }
            return searchUser.GetAllUsers();
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
    }
}
