using NUnit.Framework;
using System;
using System.Collections.Generic;
using TorfSklep.Modules.UserRegistration.Domain;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Domain.UnitTests;
using TorfSklep.Modules.UserRegistration.Respository;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace Tests
{
    public class UserRegisterTests
    {
        private IUserRegistration userRegistration;
        private ICheckingAvailabilityUserLogin usernameAvability;
        private IUsersRepository userRepository;
        private IUserRepository_insert insertUser;
        [SetUp]
        public void Setup()
        {
            this.userRepository = new UsersRepository(DataBaseType.InFile);
            //usernameAvability =  new Fake_UserLoginAvability();
            usernameAvability = new UserNameAvability(userRepository);
            this.userRegistration = new UserRegistration(userRepository, usernameAvability);
        }

        [Test]
        public void ShouldRegisterUser_WhenLoginIsAvailable()
        {
            //given
                string userLogin = "wolnylogin";
            //when
                bool result = usernameAvability.WhetherLoginNameIsAvailable(userLogin);
            //then
            Assert.IsTrue(result);
          
        }
        [Test]
        [TestCase(DataBaseType.InFile)]
        [TestCase(DataBaseType.InMemmory)]
        public void ShouldNotRegisterUser_WhenLoginIsNotAvailable(DataBaseType dbType)
        {
            if ((int)dbType == 0)
            {
                this.userRepository = new UsersRepository( DataBaseType.InMemmory);
            }
            if ((int)dbType == 1)
            {
                this.userRepository = new UsersRepository( DataBaseType.InFile);
            }
            //given
            string userLogin = "zajetyLogin";
            //when
                bool result = usernameAvability.WhetherLoginNameIsAvailable(userLogin);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        [TestCase(DataBaseType.InFile)]
        [TestCase(DataBaseType.InMemmory)]
        public void ShouldRegisterUser_whenLoginIsAvailableAndAllNecessaryUserDataIsAdd(DataBaseType dbType)
        {
            //given
            if ((int)dbType == 0)
            {
                this.userRepository = new UsersRepository(DataBaseType.InMemmory);

            }
            if ((int)dbType == 1)
            {
                this.userRepository = new UsersRepository(DataBaseType.InFile);
            }
            

            string loginName = "wolnylogin";
            //and

            bool result = usernameAvability.WhetherLoginNameIsAvailable(loginName);
            Assert.IsTrue(result);
            //when
            User users = new User() { user_id = 2, user_name = "imie2", user_login = "imie2nazwisko2", user_email = "email2@" };
            var resultdb = userRepository.SearchUser(users.user_id);
            //then
            Assert.AreEqual(users.user_id, resultdb.user_id);
            Assert.AreEqual(users.user_name, resultdb.user_name);
            Assert.AreEqual(users.user_login, resultdb.user_login);
        }

        [Test]
        public void ShouldNotRegister_whenLoginIsAvailableAndUserDataIsWrong()
        {
            //given
                string loginName = "zajetyLogin";
            User users = new User() { user_login = loginName };
            //when
            bool result = this.userRegistration.RegisterUser(users);
            //then
            Assert.IsFalse(result);
        }
    }
}