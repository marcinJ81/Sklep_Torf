using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces
{
   public interface IDscountsRules
    {
        bool SetRebateRules();

        bool RebateType(int rebate_id);
    }
}
