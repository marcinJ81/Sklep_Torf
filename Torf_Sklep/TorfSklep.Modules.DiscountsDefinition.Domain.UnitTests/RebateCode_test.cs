using NUnit.Framework;

namespace Tests
{
    public class RebateCode_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region positive_test_AssignCodeToDefinition
        [Test]
        public void AssignCodeToDefinition_When_AmountBiggerZeroAndEndDateIsNull()
        { }
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