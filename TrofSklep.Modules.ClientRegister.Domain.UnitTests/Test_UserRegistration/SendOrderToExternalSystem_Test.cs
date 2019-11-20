using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.Class;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_UserRegistration
{
   public class SendOrderToExternalSystem_Test
    {
        private ExternalSytemComunication externalSytemComunication;

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
