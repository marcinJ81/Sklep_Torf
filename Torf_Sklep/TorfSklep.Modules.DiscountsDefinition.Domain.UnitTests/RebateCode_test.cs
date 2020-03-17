using NUnit.Framework;
using System;
using TorfSklep.Modules.DiscountsDefinition.Domain;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateCode;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace Tests
{
    public class RebateCode_Tests
    {
        private IAssignRebateToDefinition assignRebateToDefinition; 
        private IReadRebateDefinition readRebate_fake;
        private ICodeRebateFunctions codeRebate_fake;
        [SetUp]
        public void Setup()
        {
            this.readRebate_fake = new Fake_DefiningRebate();
            this.codeRebate_fake = new Fake_CodeRebate();

            this.assignRebateToDefinition = new RebateCode(this.readRebate_fake, this.codeRebate_fake);
        }

        #region positive_test_AssignCodeToDefinition
        [Test]
        public void AssignCodeToDefinition_When_AmountBiggerZeroAndEndDateIsNull()
        {
            //given
            //get specific rebate definition 
            int rebate_id = 1;
            //and
            DateTime? endDate = this.readRebate_fake.ReadSpecificRebate(rebate_id).Rebate_EndDate;
            //when
           bool result = this.assignRebateToDefinition.AssignRebateCodeToDefinition(rebate_id);
            //then
            Assert.IsTrue(result);
            //and
            Assert.IsNull(endDate);
        }
        [Test]
        public void AssignCodeToDefinition_When_AmountBiggerZerotAndEndDateIsNotNull()
        {
            //given
            //get specific rebate definition 
            int rebate_id = 2;
            //and
            DateTime? endDate = this.readRebate_fake.ReadSpecificRebate(rebate_id).Rebate_EndDate;
            //when
            bool result = this.assignRebateToDefinition.AssignRebateCodeToDefinition(rebate_id);
            //then
            Assert.IsTrue(result);
            //and
            Assert.IsNotNull(endDate);
        }
        #endregion

        #region negative_test_AssignCodeToDefinition
        [Test]
        public void NotAssignCodeToDefinitions_When_AmountEqualNull()
        { }
        #endregion

        #region positive_test_CreateRebateCode
        [Test]
        public void CreateRebateCode_When_AmountIsNullAndEndDate()
        { }
        [Test]
        public void CreateRebateCod_When_AmonutIsNullEndDateIsNotNull()
        { }
        #endregion

        #region negative_test_CreateRebateCode
        [Test]
        public void NotCreateRebateCode_When_AmountIsNotNull()
        { }
        #endregion


    }
}