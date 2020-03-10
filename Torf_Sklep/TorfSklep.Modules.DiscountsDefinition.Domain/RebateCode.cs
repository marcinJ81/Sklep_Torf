using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;

namespace TorfSklep.Modules.DiscountsDefinition.Domain
{
    public class RebateCode : ICreateAndGenerateRebateCode
    {
        public bool AssignRebateCodeToDefinition(int codeR_id, int rebate_id)
        {
            throw new NotImplementedException();
        }

        public bool CreateRebateCode(int rebate_id, string nameCode)
        {
            throw new NotImplementedException();
        }
    }
}
