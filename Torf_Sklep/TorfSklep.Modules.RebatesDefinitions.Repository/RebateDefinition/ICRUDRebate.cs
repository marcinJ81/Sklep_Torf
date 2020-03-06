using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition
{
    public interface ICreateAndReadRebate
    {
        bool CreateRebateRules(DateTime beginDate, DateTime expDate, int? amount);
        Rebate ReadSpecificRebate(int rebate_id);
        List<Rebate> ReadAllRebate(); 
    }
    public interface IAddTypeRebate
    {
        bool AddTypeRebate(int rebate_id, int typeValue, decimal amount);
    }
}
