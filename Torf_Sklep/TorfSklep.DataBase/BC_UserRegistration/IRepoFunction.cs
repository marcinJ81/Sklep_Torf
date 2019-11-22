using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.DataBase.BC_UserRegistration
{
    public interface IRepoFunction<T>
    {
        List<T> GetAllRows();
    }
    public class Repofunction<T> : IRepoFunction<T> where T : class, new()
    {
        private readonly DB_UserRegistration dbUser;
        public Repofunction()
        {
            this.dbUser = new DB_UserRegistration();
        }
        public List<T> GetAllRows()
        {
            List<T> result = new List<T>();
            System.Threading.CancellationToken cancelToken = default(System.Threading.CancellationToken);
            IDbConnection connect = this.dbUser.GetOpenConnection();
            string sqlText = @"select * from user_register";

            CommandDefinition command = new CommandDefinition(sqlText, null, null, null, CommandType.Text, CommandFlags.None, cancelToken);

            var reader = connect.ExecuteReader(command);
            while (reader.Read())
            {
                result = reader.Parse<T>().ToList();
            }
            return result;
        }
    }
}
