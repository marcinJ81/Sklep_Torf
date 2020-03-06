using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_RebateRules
{
   public class RebateRules_test
    {
        private IDscountsRules SetRules;
        [SetUp]
        public void Setup()
        {
            this.SetRules = new DiscountsRules();
        }

        [Test]
        public void SetRulesWhen_BeginDateIsNow()
        {
            //given
            DateTime BeginRebate = DateTime.Now;
            //when
            bool result = SetRules.SetRebateRules();
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void NotSetRulesWhen_BeginDateWasYesterday()
        {
            //given
            DateTime ExpiredDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
            //when
            bool result = SetRules.SetRebateRules();
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void SetTypeRebatWhen_ValueIsBiggerZero()
        {
            //given
            decimal rebateValue = 1.0m;
            //and
            int rebate_id = 1;
            //when
            bool result = SetRules.RebateType(rebate_id);
            //then
            Assert.IsTrue(result);
        }
    }
}
