using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class
{
    public class Fake_DefiningRebate : ICreateAndReadRebate, IAddTypeRebate
    {
        public bool AddTypeRebate(int rebate_id, int typeValue, decimal amount)
        {
            if (typeValue == 10)
                return true;
            return false;
        }

        public bool CreateRebateRules(DateTime beginDate, DateTime? expDate, int? amount)
        {
            if(beginDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                return true;
            if ((beginDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                && expDate is null)
                return true;
            return false;
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
