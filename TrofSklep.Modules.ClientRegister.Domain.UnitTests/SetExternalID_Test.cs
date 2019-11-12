using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
   public class SetExternalID_Test
    {
        private IUserRegistration userRegistration;
        private Fake_UserLoginAvability fake_UserLoginAvability;
        private IUsersRepository userRepository;

        [SetUp]
        public void Setup()
        {
           
           
        }

        [Test]
        public void ShouldSetExternalID_WhenIDNotSet()
        {
            //given
            int id_user = 1;
            //when
            bool result = userRegistration.AssignAnExternalIdentifier(id_user);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSetExternalID_WhenIDSet()
        {
            //given
            int id_user = 0;
            //when
            bool result = userRegistration.AssignAnExternalIdentifier(id_user);
            //then
            Assert.IsTrue(result);
        }
    }
}
