using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_UserRegistration
{
    public class VerifyAccount_Test
    {
        private IUserRegistration userRegistration;
        private Fake_UserLoginAvability fake_UserLoginAvability;
        private Fake_RequestVerificationAccount fake_verificationAccount;
        private IUsersRepository userRepository;
        private Fake_MailSystem fake_sendEmail;
        [SetUp]
        public void Setup()
        {
            this.fake_UserLoginAvability = new Fake_UserLoginAvability();
            this.userRepository = new Fake_UserRepositoryForTest();
            this.fake_verificationAccount = new Fake_RequestVerificationAccount();
            this.fake_sendEmail = new Fake_MailSystem();
            this.userRegistration = new UserRegistration(
                                    userRepository,
                                    fake_UserLoginAvability,
                                    fake_verificationAccount,
                                    fake_sendEmail);
        }

        [Test]
        public void ShouldVerifyAccont_WhenTokenIsValid()
        {
            //given
            int user_id = 1;
            //when
            bool result = this.userRegistration.VerifyTheAccount(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotVerifyAccount_WhenTokenIsNotValid()
        {
            //given
            int user_id = 0;
            //when
            bool result = this.userRegistration.VerifyTheAccount(user_id);
            //then
            Assert.IsFalse(result);
        }

    }
}
