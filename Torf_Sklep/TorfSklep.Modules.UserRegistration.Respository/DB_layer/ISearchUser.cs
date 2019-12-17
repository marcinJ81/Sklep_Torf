using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface ISearchUser
    {
        User SearchUser_paramId(int id_user);
        List<User> GetAllUsers();
    }
    public class SearchUser : ADBInMemory,ISearchUser
    {
        public SearchUser() 
            : base() { }
        public User SearchUser_paramId(int id_user)
        {
            List<User> result = GetAllUsers();
            var source = result.Where(x => x.user_id == id_user).First();
            return source;
        }

        public List<User> GetAllUsers()
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            queryDictionary.Add("Create", createTable);
           // queryDictionary.Add("Insert", selectUserTable);
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
