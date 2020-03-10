using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces
{
    public interface ICreateAndGenerateRebateCode
    {
        bool AssignRebateCodeToDefinition(int codeR_id, int rebate_id);
        bool CreateRebateCode(int rebate_id, string nameCode);
    }
}
