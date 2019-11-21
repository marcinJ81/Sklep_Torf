using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.DataBase.BC_UserRegistration
{
    public interface IDBConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
