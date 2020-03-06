﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition
{
   public class Rebate
    {
        
        protected Rebate() { }
        protected int Rebate_id { get; set; }
        protected DateTime Rebate_BeginDate { get; set; }
        protected DateTime Rebate_EndDate { get; set; }
        protected int? Rebate_Amount { get; set; }
        protected int Rebate_ValueType { get; set; }
        protected decimal Rebate_Value { get; set; } 
        protected DateTime? Rebate_Expired { get; set; }
    }
}