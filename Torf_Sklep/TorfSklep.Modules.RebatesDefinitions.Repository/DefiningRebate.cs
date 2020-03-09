using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.RebatesDefinitions.Repository
{
    public class DefiningRebate : Rebate, ICreateAndReadRebate, IAddTypeRebate
    {
        public bool AddTypeRebate(int rebate_id, int typeValue, decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool CreateRebateRules(DateTime beginDate, DateTime? expDate, int? amount)
        {
            throw new NotImplementedException();
        }

        public List<Rebate> ReadAllRebate()
        {
            throw new NotImplementedException();
        }

        public Rebate ReadSpecificRebate(int rebate_id)
        {
            throw new NotImplementedException();
        }
    }
}
