using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition
{
   public class Rebate
    {
        public Rebate(int rebate_id, DateTime rebate_BeginDate, DateTime rebate_EndDate, int? rebate_Amount)
        {
            Rebate_id = rebate_id;
            Rebate_BeginDate = rebate_BeginDate;
            Rebate_EndDate = rebate_EndDate;
            Rebate_Amount = rebate_Amount;
        }

        protected int Rebate_id { get; set; }
        protected DateTime Rebate_BeginDate { get; set; }
        protected DateTime Rebate_EndDate { get; set; }
        protected int? Rebate_Amount { get; set; }
        protected int Rebate_ValueType { get; set; }
        protected decimal Rebate_Value { get; set; }  
    }
}
