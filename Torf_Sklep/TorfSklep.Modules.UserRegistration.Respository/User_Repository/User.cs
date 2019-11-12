using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository
{
    public class User
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_login { get; set; }
        public string user_email { get; set; }
        public int user_account_active { get; set; }
        public bool user_ban { get; set; }
        public string external_id { get; set; }
    }
}
