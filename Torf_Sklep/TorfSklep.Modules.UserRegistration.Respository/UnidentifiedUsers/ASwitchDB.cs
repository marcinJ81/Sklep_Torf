using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
   public abstract class ASwitchDB
    {

    }


    public class InfileDB : IInFile_User
    {
        protected IQuerySqlite testDataBase;
    }
    public interface IInFile_User
    {

    }

    
    public interface IInMemory<T>
    {
        List<T> select_AllRows();
        bool insert_OneElement(T sometable);
        bool delete_OneElement(T sometable);
        T update_OneElement(T sometable);
    }
}
