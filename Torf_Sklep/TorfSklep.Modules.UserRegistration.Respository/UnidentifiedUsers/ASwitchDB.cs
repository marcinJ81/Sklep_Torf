using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class ASwitchDB 
    {
        protected IQuerySqlite testDataBase;
        public ASwitchDB(DataBaseType choise)
        {
            if ((int)choise == 0)
            {
                this.testDataBase = new TestDataBase_InMemmory();
            }
            if ((int)choise == 1)
            {
                this.testDataBase = new TestDataBase_InFile();
            }
            
        }
    }
    public class TestRepoInFile : ASwitchDB
    {
        public IInFileDB<User> firstUseFileDB { get; }
        public IInFileMemmoryDB<User> fileMemmoryDB { get; }
        public TestRepoInFile(IInFileMemmoryDB<User> MemmoryDB, DataBaseType choise, IInFileDB<User> firstUseDBFile)
            :base(choise)
        {
            this.firstUseFileDB = firstUseDBFile;
            this.fileMemmoryDB = MemmoryDB;
        }
    }
    public class TestRepoInMemmory : ASwitchDB
    {
        public IInFileMemmoryDB<User> fileMemmoryDB { get; }
        public TestRepoInMemmory(IInFileMemmoryDB<User> fileMemmoryDB, DataBaseType choise)
            : base(choise)
        {

        }
    }


    public interface IInFileDB<T>
    {
        bool create_table();
        bool drop_table();
        bool insert_testData();
    }
    public interface IInFileMemmoryDB<T>
    {
        List<T> select_AllRows();
        bool insert_OneElement(T sometable);
        bool delete_OneElement(T sometable);
        T update_OneElement(T sometable);
    }
}
