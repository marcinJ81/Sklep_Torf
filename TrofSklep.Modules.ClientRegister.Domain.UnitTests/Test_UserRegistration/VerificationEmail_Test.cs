using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Test_UserRegistration
{
    public class VerificationEmail_Test
    {
        private ISendVerificationEmail verificationEmail;
        private IVerificationAccount requestVerificationAccount;
        private ISendEmail mailSystem;
        [SetUp]
        public void Setup()
        {
            this.requestVerificationAccount = new Fake_RequestVerificationAccount();
            this.mailSystem = new Fake_MailSystem();
            this.verificationEmail = new FirstVerificationMail(requestVerificationAccount,mailSystem);
        }
        [Test]
        public void ShouldSendMailFirstTime_WhenAccountNotBeenVerificate()
        {
            //given
            int user_id = 1;
            //when
            bool result = verificationEmail.SendVerificationEmail(user_id);
            //then
            Assert.IsTrue(result);
        }
        public void ShouldSendMailSecondTime_WhenAccountNotBeenVerificate()
        {
            // given
            int user_id = 0;
            //when
            bool result = verificationEmail.SendVerificationEmail(user_id);
            //then
            Assert.IsFalse(result);
        }

    }
}
