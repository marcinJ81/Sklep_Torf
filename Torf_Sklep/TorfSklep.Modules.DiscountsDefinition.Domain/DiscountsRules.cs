using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Enums;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.DiscountsDefinition.Domain.SimpleClass;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.DiscountsDefinition.Domain
{
    public class DiscountsRules : IDscountsRules
    {
        private readonly IAddTypeRebate typeRebate;
        private readonly ICreateAndReadRebate createRebate;

        public DiscountsRules(IAddTypeRebate typeRebate, ICreateAndReadRebate createRebate)
        {
            this.typeRebate = typeRebate;
            this.createRebate = createRebate;
        }

        public bool RebateType(int rebate_id, VaLueTypeRebate typeRebate, decimal valueRebate)
        {
            if (!this.typeRebate.AddTypeRebate(rebate_id, typeRebate, valueRebate))
            {
                return false;
            }
            return true;
        }

        public bool SetRebateRules(DateTime beginDate, DateTime? endDate, int? amount)
        {
            if (!createRebate.CreateRebateRules(beginDate,endDate,amount))
            {
                return false;
            }
            return true;
        }
    }
}
