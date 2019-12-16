using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class AQueryDefinition
    {
        public IMethodDB_File_Memmory imethodDB { get; }
        public  AQueryDefinition(DataBaseType choise)
        {
            if ((int)choise == 0)
            {
                this.imethodDB = new DBInMemory();
            }
            if ((int)choise == 1)
            {
                this.imethodDB = new DBInFile();
            }  
        }
       
    }
}
