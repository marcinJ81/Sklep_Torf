using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class
{
    public class Fake_CodeRebate : ICreateRebateCode, IAssignRebateToDefinition
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
