using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Enums;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.DiscountsDefinition.Domain.SimpleClass;

namespace TorfSklep.Modules.DiscountsDefinition.Domain
{
    public class DiscountsRules : IDscountsRules
    {
        public bool RebateType(int rebate_id, VaLueTypeRebate typeRebate, decimal vauleRebate)
        {
            throw new NotImplementedException();
        }

        public bool SetRebateRules(DateTime beginDate, DateTime expDate, int? amount)
        {
            throw new NotImplementedException();
        }
    }
}
