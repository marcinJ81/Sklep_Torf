using NUnit.Framework;
using Torf_Sklep.Infrastructure.EmailSystem;

namespace Tests
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

        [Test]
        [Ignore("Not implemented")]
        public void ShouldVerificationToken_WhenIsValid()
        {
            //given
            //when
            //then
        }

    }
}