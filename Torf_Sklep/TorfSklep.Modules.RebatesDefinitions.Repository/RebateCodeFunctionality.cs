using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateCode;

namespace TorfSklep.Modules.RebatesDefinitions.Repository
{
    public class RebateCodeFunctionality : RebateCodeTable, ICodeRebateFunctions
    {
        public List<RebateCodeTable> GetListOfCode(string category)
        {
            throw new NotImplementedException();
        }

        public List<RebateCodeTable> GetListOfCode()
        {
            throw new NotImplementedException();
        }

        public RebateCodeTable GetOneRebateCode(int rebateC_id)
        {
            throw new NotImplementedException();
        }

        public bool JoinDefinitionAndCode(int rebate_id)
        {
            throw new NotImplementedException();
        }

        public bool JoinDefinitionAndCode(int rebate_id, string codeName)
        {
            throw new NotImplementedException();
        }
    }
}
