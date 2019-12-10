using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Class;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
   public class SetExternalID_Test
    {
        private IExternalSytemComunication externalSystem;
        private IUsersRepository userRepository;
        private IExternalIdFunctions externalId;

        [SetUp]
        public void Setup()
        {
            this.externalId = new ExternalID();
            this.userRepository = new Fake_UserRepositoryForTest();
            this.externalSystem = new ExternalSytemComunication(externalId,userRepository);
        }

        [Test]
        public void ShouldSetExternalID_WhenIDNotSet()
        {
            //given
            int id_user = 0;
            //when
            bool result = externalSystem.AssignAnExternalIdentifier(id_user);
            //then
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotSetExternalID_WhenIDIsSet()
        {
            //given
            int id_user = 1;
            //when
            bool result = externalSystem.AssignAnExternalIdentifier(id_user);
            //then
            Assert.IsFalse(result);
        }
    }
}
