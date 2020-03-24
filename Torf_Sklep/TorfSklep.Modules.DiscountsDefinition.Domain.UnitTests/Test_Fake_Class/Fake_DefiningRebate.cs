using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Enums;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class
{
    public class Fake_DefiningRebate : ICreateRebateDefinition, IAddTypeRebate, IReadRebateDefinition
    {
        public bool AddTypeRebate(int rebate_id, int typeValue, decimal amount)
        {
            if (!(amount > 0 && amount < 1) != ((int)VaLueTypeRebate.Percent != typeValue))
                return false;
            if (amount <= 0)
                return false;
            if (!(((int)VaLueTypeRebate.Value != typeValue) != ((int)VaLueTypeRebate.Percent != typeValue)))
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
            TimeSpan timeSpan = new TimeSpan(5, 0, 0, 0, 0);
            DateTime? endDate = DateTime.Now + timeSpan;

            List<Rebate> fakeRebateDefinition = new List<Rebate>
            {
                new Rebate
                {
                    Rebate_id = 1,
                    Rebate_Amount = 10,
                    Rebate_BeginDate = DateTime.Now,
                    Rebate_EndDate = null,
                    Rebate_Name = "Ilosc ograniczona",
                    Rebate_Value = 0.5m,
                    Rebate_ValueType = 20,
                    Rebate_Expired = null
                },
                new Rebate
                {
                    Rebate_id = 2,
                    Rebate_Amount = 10,
                    Rebate_BeginDate = DateTime.Now,
                    Rebate_EndDate = endDate,
                    Rebate_Name = "ilosc i data ograniczona",
                    Rebate_Value = 1,
                    Rebate_ValueType = 10,
                    Rebate_Expired = null
                },
                new Rebate
                {
                    Rebate_id = 3,
                    Rebate_Amount = null,
                    Rebate_BeginDate = DateTime.Now,
                    Rebate_EndDate = null,
                    Rebate_Name = "brak ograniczen",
                    Rebate_Value = 1,
                    Rebate_ValueType = 10,
                    Rebate_Expired = null
                },
                new Rebate
                {
                    Rebate_id = 4,
                    Rebate_Amount = null,
                    Rebate_BeginDate = DateTime.Now,
                    Rebate_EndDate = endDate,
                    Rebate_Name = "brak ilosci jest data ograniczenia",
                    Rebate_Value = 1,
                    Rebate_ValueType = 10,
                    Rebate_Expired = null
                }
            };

            return fakeRebateDefinition;
        }

        public Rebate ReadSpecificRebate(int rebate_id)
        {
           var result =  ReadAllRebate();
            var onerRow = result.Where(x => x.Rebate_id == rebate_id).First();
            return onerRow;
        }
    }
}
