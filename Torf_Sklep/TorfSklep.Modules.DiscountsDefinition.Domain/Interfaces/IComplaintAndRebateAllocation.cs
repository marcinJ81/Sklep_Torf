using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces
{
    public interface IComplaintAndRebateAllocation
    {
        bool GetComplaintToRebateAllocation(int complaint_id);
    }
}
