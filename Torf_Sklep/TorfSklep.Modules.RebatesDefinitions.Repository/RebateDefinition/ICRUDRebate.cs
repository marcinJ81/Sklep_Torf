using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition
{
    public interface IReadRebate<T>
    {
        T ReadSpecificRebate(int rebate_id);
        List<T> ReadAllRebate(); 
    }
    public interface IAddTypeRebate
    {
        bool AddTypeRebate(int rebate_id, int typeValue, decimal amount);
    }
    public interface ICreateRebateDefinition
    {
        bool CreateRebateRules(DateTime beginDate, DateTime? endDate, int? amount);
    }
}
