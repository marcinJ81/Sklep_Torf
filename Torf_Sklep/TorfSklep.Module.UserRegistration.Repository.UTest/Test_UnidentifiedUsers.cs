using NUnit.Framework;
using TorfSklep.DataBase.BC_UserRegistration;
using TorfSklep.Module.UserRegistration.Repository.UTest;
using TorfSklep.Modules.UserRegistration.Domain;
using TorfSklep.Modules.UserRegistration.Domain.Tests;
using TorfSklep.Modules.UserRegistration.Respository;

namespace Tests
{
    public class Test_UnidentifiedUsers
    {
        private DB_Methods dbMethods;
        private IUsersRepository userRepo;
        private IUserRegistration userRegistration;
        private Fake_UserLoginAvability fake_UserLoginAvability;
        [SetUp]
        public void Setup()
        {
            this.userRepo = new Fake_userRepositoryInMemory();
            this.fake_UserLoginAvability = new Fake_UserLoginAvability();
            this.userRegistration = new UserRegistration(userRepo, fake_UserLoginAvability);
            dbMethods = new DB_Methods();
            this.userRepo = new Fake_userRepositoryInMemory();
        }

        [Test]
        [Ignore("Not implemented")]
        public void Test_GetUnidentifiedUsersList()
        {
            Assert.Fail();
        }
        [Test]
        public void Test_AddUnidentifiedUser()
        {
            //given
            string userLogin = "wolnylogin";
            //whenn
            bool result = userRegistration.RegisterUser(new User() { user_id = 1, user_name = "test", user_login = userLogin });
            //then
            Assert.IsTrue(result);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void Test_DeleteUserFromUnidentifiedList()
        {
            Assert.Fail();
        }
    }
}