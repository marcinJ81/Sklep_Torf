using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.Infrastructure.DataBaseSystem.DB_sklep
{
    public interface IQuerySqlite
    {
///<<<<<<< HEAD
        List<string> db_QueryWithoutParam_sqlConnectionAllInOne(string sqlCreateTable, string sqlInsert, string sqlSelect, int columnAmount);
//=======
        List<string> db_QueryWithoutParam_sqlConnectionAllInOne(Dictionary<string, string> queryString);
//>>>>>>> 7c42290... Add to interface to test code in database
    }
}
