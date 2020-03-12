using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition
{
   public class Rebate
    {  
        //change for test protected to public
        protected Rebate() { }
        protected int Rebate_id { get; set; }
        protected string Rebate_Name { get; set; }
        protected DateTime Rebate_BeginDate { get; set; }
        protected DateTime? Rebate_EndDate { get; set; }
        protected int? Rebate_Amount { get; set; }
        protected int Rebate_ValueType { get; set; }
        protected decimal Rebate_Value { get; set; } 
        protected DateTime? Rebate_Expired { get; set; }
    }
}
