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
        private IUsersRepository userRepository;
        private List<User> users;
        public RetryTheVerificationTests()
        {
            this.users = new List<User>();
        }
        [SetUp]
        public void Setup()
        {
            this.fake_UserLoginAvability = new Fake_UserLoginAvability();
            this.userRepository = new Fake_UserRepositoryForTest();
            this.userRegistration = new UserRegistration(userRepository, fake_UserLoginAvability);
            
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

    }
}
