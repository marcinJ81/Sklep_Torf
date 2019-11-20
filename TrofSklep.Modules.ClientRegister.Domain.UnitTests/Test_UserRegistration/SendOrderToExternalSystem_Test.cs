using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Class;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Domain.UnitTests.Fake_class_for_test;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_UserRegistration
{
   public class SendOrderToExternalSystem_Test
    {
        private IExternalSytemComunication externalSytemComunication;
        private IExternalIdFunctions fake_externalID;
        [SetUp]
        public void SetUp()
        {
            this.fake_externalID = new Fake_ExternalComunication();
            this.externalSytemComunication = new ExternalSytemComunication(fake_externalID);
        }
        [Test]
        public void ShouldSendFirstTimeDataToExternalSystem_WhenNumberOfAttemptsEqualsZero()
        {
            //given
            int user_id = 1;
            //when
            bool result = this.externalSytemComunication.SendOrderToExternalSystem(user_id);
            //then
            Assert.IsTrue(result);
        }
    }
}
