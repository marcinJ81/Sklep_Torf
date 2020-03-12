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
