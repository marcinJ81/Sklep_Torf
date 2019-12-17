using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface IMethodDB_File_Memmory
    {
        IUserAccountAttributes iaccountAttributes { get; }
        ICheckAndAddUser icheckandadd { get; }
        IExternalId iexternalid { get; }
        ISearchUser isearch { get; }
    }
    public class DBInMemory :  IMethodDB_File_Memmory
    {
        public DBInMemory()
        {
            this.iaccountAttributes = ;
            this.icheckandadd = ;
            this.iexternalid = ;
            this.isearch = ;
        }
        public IUserAccountAttributes iaccountAttributes { get; }
        public ICheckAndAddUser icheckandadd { get; }
        public IExternalId iexternalid { get; }
        public ISearchUser isearch { get; }
    }
}
