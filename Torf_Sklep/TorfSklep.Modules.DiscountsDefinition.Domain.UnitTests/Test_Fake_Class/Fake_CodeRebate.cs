using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateCode;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class
{
    public class Fake_CodeRebate : ICodeRebateFunctions
    {
        public List<RebateCodeTable> GetListOfCode(string category)
        {
            throw new NotImplementedException();
        }

        public RebateCodeTable GetOneRebateCode(int rebateC_id)
        {
            throw new NotImplementedException();
        }

        public bool JoinDefinitionAndCode(int rebate_id)
        {

            if (rebate_id != 1)
                return false;
            return true;
        }
    }
}
