using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfUI
{
    public class MethodDB
    {
        protected IQuerySqlite testDataBase;
        private string selectUserTable;
        public MethodDB()
        {
            this.testDataBase = new TestDataBase_InFile();
            this.selectUserTable = @"select user_id, user_name,user_sname," +
                                      "user_login,user_email, user_account_active " +
                                      " user_ban, external_id from user_register";
        }
        private string getInsertQuery(User user)
        {
            string insertQuery = @"insert into user_register values"
                                + "(" + user.user_id.ToString() + ",'" + user.user_name + "','" + user.user_sname + "','"
                                + user.user_login + "','" + user.user_email + "'," + user.user_account_active.ToString()
                                + "," + user.user_ban + "," + "'" + user.external_id + "'" + ")";
            return insertQuery;
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

        public List<User> GetAllUsers()
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
