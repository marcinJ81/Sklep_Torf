using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Class;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Domain.UnitTests.Fake_class_for_test;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_ExternalSystemComunication
{
    public class SendOrderToExternalSystem_Test
    {
        private IExternalIdFunctions fake_ExternalId;
        private ExternalSytemComunication externalSytemComunication;
        public SendOrderToExternalSystem_Test()
        {
            this.fake_ExternalId = new Fake_ExternalId();
            this.externalSytemComunication = new ExternalSytemComunication(fake_ExternalId);
        }
        [SetUp]
        public void Setup()
        {
           
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
        [Test]
        public void ShouldSendSecondTimeDataToExternalSystem_WhenNumberOfAttemptsIsGreaterThanOne()
        {
            //given
            this.fake_ExternalId = new Fake_ExternalId();
            this.externalSytemComunication = new ExternalSytemComunication(fake_ExternalId);
            int user_id = 2;
            //when
            bool result = this.externalSytemComunication.SendOrderToExternalSystem(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSendDataToExternalSystem_When_WhenNumberOfAttemptsIsEqualsLimit()
        {
            //given
            this.fake_ExternalId = new Fake_ExternalId();
            this.externalSytemComunication = new ExternalSytemComunication(fake_ExternalId);
            int user_id = 3;
            //when
            bool result = this.externalSytemComunication.SendOrderToExternalSystem(user_id);
            //then
            Assert.IsFalse(result);
        }

    }
}
