using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;


namespace TorfUI
{
    public class InsertTest
    {
        private MethodDB methodDB;
        public InsertTest()
        {
            methodDB = new MethodDB();
        }
        
        public List<User> MultipleInsertToDataBaseInFile()
        {
            
            List<User> listUsers = new List<User>()
            {new User()
                {
                    user_id = 1,
                    user_name = "imie1",
                    user_sname = "nazwisko1",
                    user_login = "imie1nazwisko1",
                    user_email = "email1@",
                    user_ban = true,
                    user_account_active = 1,
                    external_id = String.Empty
                },
                new User()
                {
                    user_id = 4,
                    user_name = "imie4",
                    user_sname = "nazw4isko4",
                    user_login = "imie4nazwisko4",
                    user_email = "email4@",
                    user_ban = true,
                    user_account_active = 0,
                    external_id = "1"
                },
                                new User()
                {
                    user_id = 5,
                    user_name = "imie5",
                    user_sname = "nazw5isko5",
                    user_login = "imie5nazwisko5",
                    user_email = "email5@",
                    user_ban = false,
                    user_account_active = 1,
                    external_id = "2"
                }
            };
            
            return methodDB.InsertUserToFile(listUsers);
        }
    }
}
