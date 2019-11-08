using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
   public  class RetryTheVerificationTests
    {
        private IUserRegistration userRegistration;
        private Fake_UserLoginAvability fake_UserLoginAvability;
        private Fake_RequestVerificationAccount fake_verificationAccount;
        private IUsersRepository userRepository;
        [SetUp]
        public void Setup()
        {
            this.fake_UserLoginAvability = new Fake_UserLoginAvability();
            this.userRepository = new Fake_UserRepositoryForTest();
            this.fake_verificationAccount = new Fake_RequestVerificationAccount();
            this.userRegistration = new UserRegistration(
                                    userRepository, 
                                    fake_UserLoginAvability,
                                    fake_verificationAccount);
        }

        [Test]
        public void ShouldSendVerificationEmail_WhenAccountIsRegister()
        {
            //given
            int user_id = 1;
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountIsNotRegister()
        {
            //given
            int user_id = 2; 
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountIsNotActive()
        {
            //given
            int user_id = 0;
            //and
            
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldSendVerificationEmail_WhenAccountIsActive()
        {
            //given
            int user_id = 1;
       
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountHaveBan()
        {
            //given
            int user_id = 0;
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldSendVerificationEmail_WhenAccountDoNotHaveBan()
        {
            //given
            int user_id = 1;
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldSendVerificationEmail_WhenAccountDoNotHaveRequestForVerification()
        {
            //given
            int user_id = 0;
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsFalse(result);
        }

    }
}
