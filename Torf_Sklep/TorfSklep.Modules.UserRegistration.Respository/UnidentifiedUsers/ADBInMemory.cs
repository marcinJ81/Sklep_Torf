using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class ADBInMemory
    {
        protected IQuerySqlite testDataBase;
        public string createTable { get; }
        public string selectUserTable { get; }
    }
}
