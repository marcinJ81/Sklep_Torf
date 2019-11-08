using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        private User users;

        [SetUp]
        public void Setup()
        {
            this.fake_UserLoginAvability = new Fake_UserLoginAvability();
            this.userRepository = new Fake_UserRepositoryForTest();
            this.userRegistration = new UserRegistration(userRepository, fake_UserLoginAvability);
            this.users = new User()
            {
                user_id = 1,
                user_name = "test",
                user_login = "wolnylogin",
                user_account_active = 1,
                user_email = "test@test"
            };
        }

        [Test]
        public void ShouldSendVerificationEmail_WhenAccountIsRegister()
        {
            //given
            int user_id = this.users.user_id;
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountIsNotRegister()
        {
            //given
            int user_id = 0;
            //when
            bool result = userRegistration.SendVerificationEmail(user_id);
            //then
            Assert.IsFalse(result);
        }


        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountIsNotActive()
        {
            //given
           
            //when
           
            //then
           
        }

    }
}
