using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class MailSystemTest
    {
        private ISendEmail sendEmail;

        [SetUp]
        public void Setup()
        {
            this.sendEmail = new MailSystem();  
        }

        [Test]
        [Ignore("Not implemented")]
        public void ShouldSendEmail_WhenUserExist()
        {
            //given
            //when
            //then

        }

    }
}
