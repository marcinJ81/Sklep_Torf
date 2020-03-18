using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateCode;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.DiscountsDefinition.Domain
{
    public class RebateCode : ICreateRebateCode, IAssignRebateToDefinition
    {
        private IReadRebateDefinition readRebate;
        private ICodeRebateFunctions readCodeRebate;

        public RebateCode(IReadRebateDefinition readRebate, ICodeRebateFunctions codeRebate)
        {
            this.readRebate = readRebate;
            this.readCodeRebate = codeRebate;
        }
        public bool AssignRebateCodeToDefinition(int rebate_id)
        {
            if (!(readRebate.ReadSpecificRebate(rebate_id).Rebate_Amount > 0))
            {
                return false;
            }
            return readCodeRebate.JoinDefinitionAndCode(rebate_id);
        }

        public bool CreateRebateCode(int rebate_id, string nameCode)
        {
            if (readRebate.ReadSpecificRebate(rebate_id).Rebate_Amount != null)
            {
                return false;
            }
            return readCodeRebate.JoinDefinitionAndCode(rebate_id, nameCode);
        }
    }
}
