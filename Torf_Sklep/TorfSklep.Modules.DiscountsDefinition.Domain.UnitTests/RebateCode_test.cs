using NUnit.Framework;
using System;
using TorfSklep.Modules.DiscountsDefinition.Domain;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateDefinition;

namespace Tests
{
    public class RebateCode_Tests
    {
        private ICreateAndGenerateRebateCode rebateCode;
        private ICreateAndReadRebate readRebate;
        [SetUp]
        public void Setup()
        {
            this.readRebate = new Fake_DefiningRebate();
            this.rebateCode = new RebateCode();
        }

        #region positive_test_AssignCodeToDefinition
        [Test]
        public void AssignCodeToDefinition_When_AmountBiggerZeroAndEndDateIsNull()
        {
            //given
            //get specific rebate definition 
            int coder_id = 1;
            int rebate_id = 1;
            //when
           bool result = this.rebateCode.AssignRebateCodeToDefinition(coder_id, rebate_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void AssignCodeToDefinition_When_AmounBiggerZerotAndEndDateIsNotNull()
        { }
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