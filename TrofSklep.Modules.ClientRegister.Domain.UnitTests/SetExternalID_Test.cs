using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
   public class SetExternalID_Test
    {
        private IUserRegistration userRegistration;
        private IGenerateUserId<string> generatorID;
        [SetUp]
        public void Setup()
        {
            this.generatorID = new GeneratorId();
            this.userRegistration = new UserRegistration(this.generatorID); 
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
            int id_user = 1;
            //when
            bool result = userRegistration.AssignAnExternalIdentifier(id_user);
            //then
            Assert.IsTrue(result);
        }
    }
}
