using System;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository
{

    public class UsersRepository : AQueryDefinition, IUsersRepository
    {
        private IQuerySqlite testDataBase;
        public UsersRepository(TableName tableName)
        :base(tableName)
        {
            this.testDataBase = new TestDataBase();
        }
        public bool AddUser(User user)
        {
            string insertQuery = @"insert into user_register values"
                                + "(" + user.user_id.ToString() + ",'" + user.user_name + "','" + user.user_sname + "','"
                                + user.user_login +"','"+user.user_email+"',"+user.user_account_active.ToString()
                                + "," + user.user_ban +","+"'"+user.external_id+ "'" +")";


            var result = testDataBase.db_QueryWithoutParam_sqlConnectionAllInOne(createTable, insertQuery, selectUserTable, 3);
            if (result.Count == 2)
                return true;
            return false;
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountActive(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountHaveBan(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsExternalIDSet(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsThereAUserExist(int id_user)
        {
            throw new NotImplementedException();
        }

        public User SearchUser(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
