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

        public RebateCodeTable GetOneRebateCode(int rebateC_id)
        {
            throw new NotImplementedException();
        }
    }
}
