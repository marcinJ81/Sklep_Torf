﻿using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Enums;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class
{
    public class Fake_DefiningRebate : ICreateAndReadRebate, IAddTypeRebate
    {
        public bool AddTypeRebate(int rebate_id, int typeValue, decimal amount)
        {
            if (amount <= 0)
                return false;
            if (!(((int)VaLueTypeRebate.Value != typeValue) ^ ((int)VaLueTypeRebate.Percent != typeValue)))
                return false;
            return true;
        }

        public bool CreateRebateRules(DateTime beginDate, DateTime? expDate, int? amount)
        {
            if (beginDate.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return true;
            }
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
