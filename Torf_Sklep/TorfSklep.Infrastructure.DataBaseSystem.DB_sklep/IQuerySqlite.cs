using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.Infrastructure.DataBaseSystem.DB_sklep
{
    public interface IQuerySqlite
    {
        List<string> db_QueryWithoutParam_sqlConnectionAllInOne(string sqlCreateTable, string sqlInsert, string sqlSelect, int columnAmount);
    }
}
