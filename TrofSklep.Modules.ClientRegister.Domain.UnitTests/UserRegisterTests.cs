using NUnit.Framework;
using TorfSklep.Modules.UserRegistration.Domain;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Domain.UnitTests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace Tests
{
    public class UserRegisterTests
    {
        private IUserRegistration userRegistration;
        private Fake_UserLoginAvability fake_UserLoginAvability;
        private IUsersRepository userRepository;
        [SetUp]
        public void Setup()
        {
            this.fake_UserLoginAvability = new Fake_UserLoginAvability();
            this.userRepository = new Fake_UserRepositoryForTest();
            this.userRegistration = new UserRegistration(userRepository,fake_UserLoginAvability);
        }

        [Test]
        public void ShouldRegisterUser_WhenLoginIsAvailable()
        {
            //given
                string userLogin = "wolnylogin";
                User users = new User() { user_id = 1, user_name = "test",user_login = userLogin};
            //when
                bool result = this.userRegistration.RegisterUser(users);
            //then
                Assert.IsTrue(result);
        }
        [Test]
        public void ShouldNotRegisterUser_WhenLoginIsNotAvailable()
        {
            //given
                string loginName = "zajetyLogin";
                User users = new User() { user_id = 1, user_name = "test", user_login = loginName };
                bool result = this.userRegistration.RegisterUser(users);
                Assert.IsFalse(result);
            //when
                result = userRegistration.RegisterUser(users);
            //then
                Assert.IsFalse(result);
        }
        [Test]
        public void ShouldRegisterUser_whenLoginIsAvailableAndAllNecessaryUserDataIsAdd()
        {
            //given
                string loginName = "wolnylogin";
                User users = new User() { user_id = 1, user_name = "test", user_login = loginName };
                bool result = this.userRegistration.RegisterUser(users);
                Assert.IsTrue(result);
            //when
                result = this.userRegistration.RegisterUser(users);
            //then
                Assert.IsTrue(result);
        }

        [Test]
        public void ShouldNotRegister_whenLoginIsAvailableAndUserDataIsWrong()
        {
            //given
                string loginName = "wolnylogin";
                User users = new User() { user_id = 1, user_name = "test", user_login = loginName };
                bool result = this.userRegistration.RegisterUser(users);
                Assert.IsTrue(result);
            //and
                users.user_name = "brak";
            //when
                result = this.userRegistration.RegisterUser(users);
            //then
                Assert.IsFalse(result);
        }
       
    }
}