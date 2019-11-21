using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TorfSklep.DataBase.BC_UserRegistration
{
    public class DB_Methods
    {
        private readonly DB_UserRegistration dbUser;

        public DB_Methods()
        {
            this.dbUser = new DB_UserRegistration();
        }
        public int db_QueryWithoutParam_IDbConnection(string sqlText)
        {
            System.Threading.CancellationToken cancelToken = default(System.Threading.CancellationToken);
            IDbConnection connect = this.dbUser.GetOpenConnection();
            CommandDefinition command = new CommandDefinition(sqlText,null,null,null,CommandType.Text,CommandFlags.None,cancelToken);
            return connect.Execute(command);
        }
        public int db_QueryWithoutParam_sqlConnection(string sqlText)
        {
            using (SqlConnection connection = new SqlConnection(
               this.dbUser.getconstring))
            {
                SqlCommand command = new SqlCommand(sqlText, connection);
                command.Connection.Open();
               return command.ExecuteNonQuery();
            }
        }
    }
}
