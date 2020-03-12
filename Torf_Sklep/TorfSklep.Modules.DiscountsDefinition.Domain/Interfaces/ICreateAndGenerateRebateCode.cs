using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces
{
    public interface ICreateRebateCode
    {
        bool CreateRebateCode(int rebate_id, string nameCode);
    }
    public interface IAssignRebateToDefinition
    {
        bool AssignRebateCodeToDefinition(int codeR_id, int rebate_id);
    }
}
