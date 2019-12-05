using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public enum Reason
    {
        Incorect_Data = 10,
        External_System_Not_Available = 20
    }

    public enum TableName
    {
        User_table = 1
    }

    public enum DataBaseType
    {
        InMemmory = 0,
        InFile = 1
    }
}
