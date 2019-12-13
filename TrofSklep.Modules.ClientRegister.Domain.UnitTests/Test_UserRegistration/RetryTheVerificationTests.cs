using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.Class;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
   public  class RetryTheVerificationTests
    {
        private Fake_RequestVerificationAccount fake_verificationAccount;
        private IUsersRepository userRepository;
        private Fake_MailSystem fake_sendEmail;
        private ISendSecondVerificationEmail sendSecondVerificationEmail;
        private string name = "marcin";
        private string sname = "juranek";
        private string email = "test@test";
        [SetUp]
        public void Setup()
        {
            this.userRepository = new Fake_UserRepositoryForTest();

            this.fake_verificationAccount = new Fake_RequestVerificationAccount();
            this.fake_sendEmail = new Fake_MailSystem();
            this.sendSecondVerificationEmail = new SecondVerificationMail(fake_verificationAccount,userRepository,fake_sendEmail);
        }

        [Test]
        public void ShouldSendVerificationEmail_WhenAccountIsRegister()
        {
            //given
            int user_id = 1;
            //and
            bool result1 = userRepository.IsThereAUserRegister(name, sname, email);
            Assert.IsTrue(result1);
            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountIsNotRegister()
        {
            //given
            int user_id = 2;
            //and
            bool result1 = userRepository.IsThereAUserRegister(name, sname, email);
            Assert.IsFalse(result1);
            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountIsNotActive()
        {
            //given
            int user_id = 0;
            //and
            bool result1 = userRepository.IsAccountActive(user_id);
            Assert.IsFalse(result1);
            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldSendVerificationEmail_WhenAccountIsActive()
        {
            //given
            int user_id = 1;
            name = "active account";
            //and

            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSendVerificationEmail_WhenAccountHaveBan()
        {
            //given
            int user_id = 0;
            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldSendVerificationEmail_WhenAccountDoNotHaveBan()
        {
            //given
            int user_id = 1;
            name = "active account";
            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldSendVerificationEmail_WhenAccountDoNotHaveRequestForVerification()
        {
            //given
            int user_id = 0;
            name = "active account";
            //when
            bool result = sendSecondVerificationEmail.SendVerificationEmail(user_id, name, sname, email);
            //then
            Assert.IsFalse(result);
        }
       


    }
}
