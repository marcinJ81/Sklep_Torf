using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateCode
{
    public interface ICodeRebateFunctions
    {
        List<RebateCodeTable> GetListOfCode(string category);
        RebateCodeTable GetOneRebateCode(int rebateC_id);
        bool JoinDefinitionAndCode( int rebate_id);
        List<RebateCodeTable> GetListOfCode();
    }
}
