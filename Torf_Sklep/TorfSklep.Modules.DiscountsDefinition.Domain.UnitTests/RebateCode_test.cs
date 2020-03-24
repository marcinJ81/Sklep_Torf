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
        private ICreateRebateCode createRebateCode;
        [SetUp]
        public void Setup()
        {

            this.readRebate_fake = new Fake_DefiningRebate();
            this.codeRebate_fake = new Fake_CodeRebate();

            this.assignRebateToDefinition = new RebateCode(this.readRebate_fake, this.codeRebate_fake);
            this.createRebateCode = new RebateCode(this.readRebate_fake, this.codeRebate_fake);
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
        {
            //given
            //get specific rebate definition 
            int rebate_id = 3;           
            //when
            bool result = this.assignRebateToDefinition.AssignRebateCodeToDefinition(rebate_id);
            //then
            Assert.IsFalse(result);
        }
        #endregion

        #region positive_test_CreateRebateCode
        [Test]
        public void CreateRebateCode_When_AmountIsNullAndEndDate()
        {
            //given
            //get specific rebate definition 
            int rebate_id = 3;
            //and
            string codeName = "sta³y rabat";

            //when
            bool result = this.createRebateCode.CreateRebateCode(rebate_id, codeName);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void CreateRebateCod_When_AmonutIsNullEndDateIsNotNull()
        {
            //given
            //get specific rebate definition 
            int rebate_id = 4;
            //and
            string codeName = "sta³y rabat";
            //and
            DateTime? endDate = this.readRebate_fake.ReadSpecificRebate(rebate_id).Rebate_EndDate;
            //when
            bool result = this.createRebateCode.CreateRebateCode(rebate_id, codeName);
            //then
            Assert.IsTrue(result);
            //and
            Assert.IsNotNull(endDate);
        }
        #endregion

        #region negative_test_CreateRebateCode
        [Test]
        public void NotCreateRebateCode_When_AmountIsNotNull()
        {
            //given
            //get specific rebate definition 
            int rebate_id = 1;
            //and
            string codeName = "zima";
            //when
            bool result = this.createRebateCode.CreateRebateCode(rebate_id, codeName);
            //then
            Assert.IsFalse(result);
        }
        #endregion


    }
}