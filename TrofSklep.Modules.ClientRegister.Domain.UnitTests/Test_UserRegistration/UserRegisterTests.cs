using NUnit.Framework;
using TorfSklep.Modules.UserRegistration.Domain;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Domain.UnitTests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace Tests
{
    public class UserRegisterTests
    {
        private IUserRegistration userRegistration;
        private ICheckingAvailabilityUserLogin usernameAvability;
        private IUsersRepository userRepository;
        [SetUp]
        public void Setup()
        {
            this.userRepository = new UsersRepository(TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers.TableName.User_table,
                TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers.DataBaseType.InFile);
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
        public void ShouldNotRegisterUser_WhenLoginIsNotAvailable()
        {
            //given
                string userLogin = "zajetyLogin";
            //when
                bool result = usernameAvability.WhetherLoginNameIsAvailable(userLogin);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldRegisterUser_whenLoginIsAvailableAndAllNecessaryUserDataIsAdd()
        {
            //given
                string loginName = "wolnylogin";
                User users = new User() { user_id = 3, user_name = "test", user_login = loginName, user_email = "test@test" };
            //when
                bool result = this.userRegistration.RegisterUser(users);
            //then
                Assert.IsTrue(result);
        }

        [Test]
        public void ShouldNotRegister_whenLoginIsAvailableAndUserDataIsWrong()
        {
            //given
                string loginName = "wolnylogin";
            User users = new User() { user_login = loginName };
            //when
            bool result = this.userRegistration.RegisterUser(users);
            //then
            Assert.IsFalse(result);
        }
        

    }
}