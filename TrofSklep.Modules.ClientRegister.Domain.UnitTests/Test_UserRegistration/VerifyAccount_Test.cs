using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.Class;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_UserRegistration
{
    public class VerifyAccount_Test
    {
        private Fake_RequestVerificationAccount fake_verificationAccount;
        private Fake_MailSystem fake_sendEmail;
        private IAccountVerification accountVerification;
        [SetUp]
        public void Setup()
        {
            this.fake_verificationAccount = new Fake_RequestVerificationAccount();
            this.fake_sendEmail = new Fake_MailSystem();
            this.accountVerification = new AccountVerification(fake_verificationAccount, fake_sendEmail);
        }

        [Test]
        public void ShouldVerifyAccont_WhenTokenIsValid()
        {
            //given
            int user_id = 1;
            //when
            bool result = this.accountVerification.VerifyTheAccount(user_id);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotVerifyAccount_WhenTokenIsNotValid()
        {
            //given
            int user_id = 0;
            //when
            bool result = this.accountVerification.VerifyTheAccount(user_id);
            //then
            Assert.IsFalse(result);
        }

    }
}
