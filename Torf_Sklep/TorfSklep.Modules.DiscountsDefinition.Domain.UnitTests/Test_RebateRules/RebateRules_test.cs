using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Enums;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_RebateRules
{
   public class RebateRules_test
    {
        private IDscountsRules SetRules;
        private ICreateAndReadRebate<Fake_Rebate> fakeRulesRepo;
        private IAddTypeRebate fakeTypeRepo;

        [SetUp]
        public void Setup()
        {
            this.fakeRulesRepo = new Fake_DefiningRebate();
            this.fakeTypeRepo = new Fake_DefiningRebate();
            this.SetRules = new DiscountsRules(fakeTypeRepo,fakeRulesRepo);
        }

        [Test]
        public void SetRulesWhen_BeginDateIsNow()
        {
            //given
            DateTime beginRebate = DateTime.Now;
            //and
            DateTime endDate = DateTime.Now;
            //and
            int? amount = null;
            //when
            bool result = SetRules.SetRebateRules(beginRebate,endDate,amount);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void NotSetRulesWhen_BeginDateIsNotForTodayAndNextDay()
        {
            //given
            DateTime beginDate = DateTime.MinValue;
            //and
            DateTime endDate = DateTime.Now;
            //and
            int? amount = null;
            //when
            bool result = SetRules.SetRebateRules(beginDate,endDate,amount);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void SetTypeValueRebatWhen_ValueIsBiggerThenZero()
        {
            //given
            decimal rebateValue = 20.0m;
            //and
            int rebate_id = 1;
            //when
            bool result = SetRules.RebateType(rebate_id,VaLueTypeRebate.Value,rebateValue);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void NotSetTypeRebateWhen_ValueIsSmallerOrEquelZero()
        {
            //given
            decimal rebateValue = 0.0m;
            //and
            int rebate_id = 1;
            //when
            bool result = SetRules.RebateType(rebate_id, VaLueTypeRebate.Value, rebateValue);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void SetRebateTypeWhen_WhenTypeIsPercentAndValueIsBetweenZeroAndOne()
        {
            //given
            decimal rebateValue = 0.10m;
            //and
            int rebate_id = 1;
            //when
            bool result = SetRules.RebateType(rebate_id, VaLueTypeRebate.Percent, rebateValue);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void SetRebateTypeWhen_WhenTypeIsPercentAndValueIsBiggerThenOne()
        {
            //given
            decimal rebateValue = 1.10m;
            //and
            int rebate_id = 1;
            //when
            bool result = SetRules.RebateType(rebate_id, VaLueTypeRebate.Percent, rebateValue);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void SetRebateTypeWhen_WhenTypeIsValue()
        {
            //given
            decimal rebateValue = 20.0m;
            //and
            int rebate_id = 1;
            //when
            bool result = SetRules.RebateType(rebate_id, VaLueTypeRebate.Value, rebateValue);
            //then
            Assert.IsTrue(result);
        }

    }
}
