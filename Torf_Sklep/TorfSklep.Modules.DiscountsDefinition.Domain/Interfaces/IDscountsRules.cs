using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Enums;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces
{
   public interface IDscountsRules
    {
        bool SetRebateRules(DateTime beginDate,DateTime? endDate,int? amount);

        bool RebateType(int rebate_id, VaLueTypeRebate typeRebate, decimal vauleRebate);
    }
}
