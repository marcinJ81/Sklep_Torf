using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace TorfSklep.Infrastructure.DataBaseSystem.DB_sklep
{
   public interface IQueryAndExecute<T>
    {
        List<T> dbQuery_sqliteInmemory(string query);
        List<T> dbQuery_sqliteInmemoryWithSqliteParametrs(string query, List<SqliteParameter> listOfParameters);
        int dbQuery_sqliteInmemoryExecut4eNonQuery(string query);
    }
}
