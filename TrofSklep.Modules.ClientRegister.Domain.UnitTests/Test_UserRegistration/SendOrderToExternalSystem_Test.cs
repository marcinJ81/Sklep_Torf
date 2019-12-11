using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Class;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Domain.UnitTests.Fake_class_for_test;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_UserRegistration
{
   public class SendOrderToExternalSystem_Test
    {
        private IExternalSytemComunication externalSytemComunication;
        private IExternalIdFunctions fake_externalID;
        private IUsersRepository userRepo;
        [SetUp]
        public void SetUp()
        {
            this.fake_externalID = new Fake_ExternalComunication();
            this.userRepo = new Fake_UserRepositoryForTest();
           // this.userRepo = new UsersRepository(TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers.TableName.User_table,
            //    TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers.DataBaseType.InFile);
            this.externalSytemComunication = new ExternalSytemComunication(fake_externalID,userRepo);
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
            int user_id = 3;
            //when
            bool result = this.externalSytemComunication.SendOrderToExternalSystem(user_id);
            //then
            Assert.IsFalse(result);
        }
    }
}
