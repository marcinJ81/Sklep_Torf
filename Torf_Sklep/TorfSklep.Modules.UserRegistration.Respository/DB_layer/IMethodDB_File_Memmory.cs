using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface IMethodDB_File_Memmory
    {
        IUserAccountAttributes iaccountAttributes { get; }
        IAddUser iadduser { get; }
        IExternalId iexternalid { get; }
        ISearchUser isearch { get; }
        ICheckUser icheckuser { get; }
    }
    public class DBInMemory :  IMethodDB_File_Memmory
    {
        public DBInMemory()
        {
            this.isearch = new SearchUser(); 
            this.iaccountAttributes = new UserAccountAttributes(isearch);
            this.iadduser = new AdditionUser(isearch);
            this.iexternalid =  new ExternalId(isearch);
            this.icheckuser = new UserChecker(isearch);
        }

        public IUserAccountAttributes iaccountAttributes { get; }

        public IAddUser iadduser { get; }

        public IExternalId iexternalid { get; }

        public ISearchUser isearch { get; }

        public ICheckUser icheckuser { get; }
    }
}
