using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition
{
   public class Rebate
    {  
        //change for test protected to public
       public Rebate() { }
        public int Rebate_id { get; set; }
        public string Rebate_Name { get; set; }
        public DateTime Rebate_BeginDate { get; set; }
        public DateTime? Rebate_EndDate { get; set; }
        public int? Rebate_Amount { get; set; }
        public int Rebate_ValueType { get; set; }
        public decimal Rebate_Value { get; set; } 
        public DateTime? Rebate_Expired { get; set; }
    }
}
